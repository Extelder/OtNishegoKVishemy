using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWealthUI : MonoBehaviour
{
    [SerializeField] private Image _wealthBar;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private CharacterWealth _wealth;

    [SerializeField] private CharacterWealthOutfit characterWealthOutfit;

    private void OnEnable()
    {
        _wealth.CurrentValueChanged += OnCurrentValueChanged;
        characterWealthOutfit.OutfitChanged += OnWealthOutfitChanged;
    }

    private void OnDisable()
    {
        _wealth.CurrentValueChanged -= OnCurrentValueChanged;
        characterWealthOutfit.OutfitChanged -= OnWealthOutfitChanged;
    }

    private void OnCurrentValueChanged(int value)
    {
        _wealthBar.fillAmount = (float) value / 100;
    }

    private void OnWealthOutfitChanged(Outfit outfit)
    {
        _text.text = outfit.Name;
        _text.color = outfit.NameColor;
    }
}