using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string _animatorInteractTriggerName;
    [SerializeField] private EnvironmentInteractable _environmentInteractable;
    [SerializeField] private float _wealthThreshold;

    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _environmentInteractable.Interacted += OnInteracted;
    }

    private void OnDisable()
    {
        _environmentInteractable.Interacted -= OnInteracted;
    }

    private void OnInteracted()
    {
        if (CharacterWealth.Instance.CurrentValue >= _wealthThreshold)
        {
            _animator.SetTrigger(_animatorInteractTriggerName);
        }
    }
}