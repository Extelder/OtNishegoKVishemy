using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private string _winAnimatorTriggerName = "Win";
    [SerializeField] private string _loseAnimatorTriggerName = "Lose";
    [SerializeField] private string _defaultWalkAnimationTriggerName = "PoorWalk";

    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameState.Instance.Winned += OnWinned;
        GameState.Instance.Losed += OnLosed;
        GameState.Instance.StartGame += OnStartedGame;
    }


    private void OnDisable()
    {
        GameState.Instance.Winned -= OnWinned;
        GameState.Instance.Losed -= OnLosed;
        GameState.Instance.StartGame -= OnStartedGame; 
    }

    
    private void OnStartedGame()
    {
        SetWalkAnimationTrigger(_defaultWalkAnimationTriggerName);
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
    
    public void ResetWalkAnimationTrigger(string name)
    {
        _animator.ResetTrigger(name);
    }
}