using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _startCanvas;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private GameObject _loseCanvas;
    public static GameState Instance { get; private set; }

    public bool GameStarted { get; private set; }

    public event Action Winned;
    public event Action Losed;
    public event Action StartGame;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more GameState in the scene!");
        Destroy(this);
    }

    private void Start()
    {
        CharacterWealth.Instance.MinValueAchieved += OnMinValueAchieved;

        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStarted = true;
                StartGame?.Invoke();
                _startCanvas.SetActive(false);
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
        CharacterWealth.Instance.MinValueAchieved -= OnMinValueAchieved;
    }

    private void OnMinValueAchieved()
    {
        Lose();
    }

    public void Win()
    {
        Winned?.Invoke();
        _winCanvas.SetActive(true);
        _moneyText.text = CharacterMoney.Instance.CurrentValue.ToString() + "$";
    }

    public void Lose()
    {
        Losed?.Invoke();
        _loseCanvas.SetActive(true);
    }
}