using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWealthPickupable : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    
    [field: SerializeField] public bool DestroyAfterInteract { get; set; }
    
    public static event Action Pickuped;

    public void Interact()
    {
        CharacterWealth.Instance.RemoveWealth(_value);
        Pickuped?.Invoke();
        if (DestroyAfterInteract)
            Destroy(gameObject);
    }
}