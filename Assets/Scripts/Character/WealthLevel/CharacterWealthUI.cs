using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWealthUI : MonoBehaviour
{
    [SerializeField] private Image _wealthBar;
    
    [SerializeField] private CharacterWealth _wealth;

    private void OnEnable()
    {
        _wealth.CurrentValueChanged += OnCurrentValueChanged;
    }

    private void OnDisable()
    {
        _wealth.CurrentValueChanged -= OnCurrentValueChanged;
    }

    private void OnCurrentValueChanged(int value)
    {
        _wealthBar.fillAmount = value / 100;
    }
}