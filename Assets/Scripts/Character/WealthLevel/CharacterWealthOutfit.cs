using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWealthOutfit : MonoBehaviour
{
    [SerializeField] private Outfit[] _outfits;
    [SerializeField] private CharacterWealth _wealth;

    private Outfit _currentOutfit;

    public event Action<Outfit> OutfitChanged;

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
        for (int i = _outfits.Length - 1; i >= 0; i--)
        {
            if (value >= _outfits[i].WealthThreshold)
            {
                if(_currentOutfit == _outfits[i])
                    return;
                _currentOutfit?.Skin.SetActive(false);
                _currentOutfit = _outfits[i];
                _currentOutfit.Skin.SetActive(true);

                OutfitChanged?.Invoke(_currentOutfit);
                return;
            }
        }
    }
}

[System.Serializable]
public class Outfit
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int WealthThreshold { get; private set; }
    [field: SerializeField] public GameObject Skin { get; private set; }
    [field: SerializeField] public Color NameColor { get; private set; }
}