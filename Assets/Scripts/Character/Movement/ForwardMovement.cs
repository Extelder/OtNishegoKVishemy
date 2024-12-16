using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        GameState.Instance.Losed += DisableMovement;
        GameState.Instance.Winned += DisableMovement;
    }

    private void OnDisable()
    {
        GameState.Instance.Losed -= DisableMovement;
        GameState.Instance.Winned -= DisableMovement;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void DisableMovement()
    {
        enabled = false;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speed);
    }
}