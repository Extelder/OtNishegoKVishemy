using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWealthOutfit : MonoBehaviour
{
    [SerializeField] private Outfit[] _outfits;
    [SerializeField] private CharacterWealth _wealth;
    [SerializeField] private CharacterAnimator _characterAnimator;

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
        if (!GameState.Instance.GameStarted)
            return;

        for (int i = _outfits.Length - 1; i >= 0; i--)
        {
            if (value >= _outfits[i].WealthThreshold)
            {
                if (_currentOutfit == _outfits[i])
                    return;
                if (_currentOutfit != null)
                {
                    _currentOutfit.Skin.SetActive(false);

                    _characterAnimator.ResetWalkAnimationTrigger(_currentOutfit.WalkAnimationTriggerName);
                }

                _currentOutfit = _outfits[i];
                _currentOutfit.Skin.SetActive(true);

                _characterAnimator.SetWalkAnimationTrigger(_currentOutfit.WalkAnimationTriggerName);
                Debug.Log(_currentOutfit.WalkAnimationTriggerName);

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
    [field: SerializeField] public string WalkAnimationTriggerName { get; private set; }
    [field: SerializeField] public int WealthThreshold { get; private set; }
    [field: SerializeField] public GameObject Skin { get; private set; }
    [field: SerializeField] public Color NameColor { get; private set; }
}