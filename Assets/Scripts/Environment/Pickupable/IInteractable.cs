using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool DestroyAfterInteract { get; set; }

    public void Interact();
}