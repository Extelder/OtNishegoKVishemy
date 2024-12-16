using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWealthChangedVFX : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Pool _removeVfxPool;
    [SerializeField] private Pool _addVfxPool;

    private void OnEnable()
    {
        RemoveWealthPickupable.Pickuped += OnRemovePickuped;
        AddWealthPickupable.Pickuped += OnAddPickuped;
    }

    private void OnDisable()
    {
        RemoveWealthPickupable.Pickuped -= OnRemovePickuped;
        AddWealthPickupable.Pickuped -= OnAddPickuped;
    }

    private void OnRemovePickuped()
    {
        _removeVfxPool.GetFreeElement(_spawnPoint.position, Quaternion.identity, _spawnPoint);
    }
    
    private void OnAddPickuped()
    {
        _addVfxPool.GetFreeElement(_spawnPoint.position, Quaternion.identity, _spawnPoint);
    }
}