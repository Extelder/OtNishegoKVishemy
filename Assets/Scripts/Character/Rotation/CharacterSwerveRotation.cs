using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CharacterSwerveRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _maxAngle = 15f;
    [SerializeField] private float _normalizeMultiplier;
    [SerializeField] private float _smoothness;

    private float _targetYRotation;

    private void Update()
    {
        _targetYRotation = _maxAngle * Mathf.Round(_rigidbody.velocity.normalized.x * _normalizeMultiplier);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
            Mathf.LerpAngle(transform.eulerAngles.y, _targetYRotation, _smoothness * Time.deltaTime),
            transform.eulerAngles.z);
    }
}