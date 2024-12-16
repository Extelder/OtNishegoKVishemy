using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
[RequireComponent(typeof(Rigidbody))]
public class SwerveMovement : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private SwerveInputSystem _swerveInputSystem;
    private Rigidbody _rigidbody;

    public float _swerveAmount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        _swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        _swerveAmount = Mathf.Clamp(_swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        _rigidbody.velocity = new Vector3(_swerveAmount, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }
}