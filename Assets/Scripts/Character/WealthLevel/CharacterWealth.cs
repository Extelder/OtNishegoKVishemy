using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWealth : MonoBehaviour
{
    public int CurrentValue { get; private set; } = 0;

    private const int MaxValue = 100;

    public event Action<int> CurrentValueChanged;

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
            return;
        }

        CurrentValue -= value;
        CurrentValueChanged?.Invoke(CurrentValue);
    }
}