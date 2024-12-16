using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private string _winAnimatorTriggerName = "Win";
    [SerializeField] private string _loseAnimatorTriggerName = "Lose";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameState.Instance.Winned += OnWinned;
        GameState.Instance.Losed += OnLosed;
    }

    private void OnDisable()
    {
        GameState.Instance.Winned -= OnWinned;
        GameState.Instance.Losed -= OnLosed;
    }

    private void OnWinned()
    {
        _animator.SetTrigger(_winAnimatorTriggerName);
    }

    private void OnLosed()
    {
        _animator.SetTrigger(_loseAnimatorTriggerName);
    }

    public void SetWalkAnimationTrigger(string name)
    {
        _animator.SetTrigger(name);
    }
}