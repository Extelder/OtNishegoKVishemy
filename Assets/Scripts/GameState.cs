using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;
    public static GameState Instance { get; private set; }

    public event Action Winned;
    public event Action Losed;

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
    }

    private void OnDisable()
    {
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
    }

    public void Lose()
    {
        Losed?.Invoke();
        _loseCanvas.SetActive(true);
    }
}