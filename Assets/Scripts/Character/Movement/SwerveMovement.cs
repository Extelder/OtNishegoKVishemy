using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
[RequireComponent(typeof(Rigidbody))]
public class SwerveMovement : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private SwerveInputSystem _swerveInputSystem;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        _rigidbody.velocity = new Vector3(swerveAmount, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }
}