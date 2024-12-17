using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoney : MonoBehaviour
{
    public int CurrentValue { get; private set; }

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

    public void Multiply(int multiplier)
    {
        CurrentValue = CharacterWealth.Instance.CurrentValue;
        CurrentValue *= multiplier;
    }
}