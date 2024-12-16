using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour, IInteractable
{
    public event Action Interacted;

    public bool DestroyAfterInteract { get; set; }

    public void Interact()
    {
        Interacted?.Invoke();
        if (DestroyAfterInteract)
            Destroy(gameObject);
    }
}