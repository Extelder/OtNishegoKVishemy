using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoney : MonoBehaviour
{
    private int _currentValue;

    public static CharacterMoney Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }
        
        Debug.LogError("There`s one more CharacterMoney in the scene!");
        Destroy(this);
    }

    public void CalculateMoneyForLevel()
    {
        _currentValue = CharacterWealth.Instance.CurrentValue;
    }

    public void Multiply(int multiplier)
    {
        _currentValue *= multiplier;
    }
}