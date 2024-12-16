using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMultipierInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private int _multiplier;
    
    public bool DestroyAfterInteract { get; set; }
    
    public void Interact()
    {
        CharacterMoney.Instance.Multiply(_multiplier);
    }
}
