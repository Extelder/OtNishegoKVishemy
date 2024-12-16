using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWealth : MonoBehaviour
{
    [SerializeField] private int _startValue;

    public int CurrentValue { get; private set; } = 0;

    private const int MaxValue = 100;

    public event Action<int> CurrentValueChanged;
    public event Action MinValueAchieved;
    
    public static CharacterWealth Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }
        
        Debug.LogError("There`s one more CharacterWealth in scene!");
        Destroy(this);
    }

    private void Start()
    {
        CurrentValue = _startValue;
        Debug.Log(CurrentValue);
        CurrentValueChanged?.Invoke(CurrentValue);
    }

    public void AddWealth(int value)
    {
        if (CurrentValue + value > MaxValue)
        {
            CurrentValue = MaxValue;
            CurrentValueChanged?.Invoke(CurrentValue);
            return;
        }

        CurrentValue += value;
        CurrentValueChanged?.Invoke(CurrentValue);
    }

    public void RemoveWealth(int value)
    {
        if (CurrentValue - value < 0)
        {
            CurrentValue = 0;
            CurrentValueChanged?.Invoke(CurrentValue);
            MinValueAchieved?.Invoke();
            return;
        }

        CurrentValue -= value;
        CurrentValueChanged?.Invoke(CurrentValue);
    }
}