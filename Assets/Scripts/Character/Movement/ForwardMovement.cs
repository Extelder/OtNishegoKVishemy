using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        GameState.Instance.Losed += DisableMovement;
        GameState.Instance.Winned += DisableMovement;
        GameState.Instance.StartGame += EnableMovement;
    }

    private void OnDisable()
    {
        GameState.Instance.Losed -= DisableMovement;
        GameState.Instance.Winned -= DisableMovement;
        GameState.Instance.StartGame -= EnableMovement;
        _disposable.Clear();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void EnableMovement()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speed);
        }).AddTo(_disposable);
    }

    private void DisableMovement()
    {
        _rigidbody.velocity = new Vector3(0, 0, 0);
        enabled = false;
    }
}