using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EnvironmentInteractAnimator : MonoBehaviour
{
    [SerializeField] private string _animatorInteractTriggerName;
    [SerializeField] private EnvironmentInteractable _interactable;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _interactable.Interacted += Interact;
    }

    private void OnDisable()
    {
        _interactable.Interacted -= Interact;
    }

    public void Interact()
    {
        _animator.SetTrigger(_animatorInteractTriggerName);
    }
}