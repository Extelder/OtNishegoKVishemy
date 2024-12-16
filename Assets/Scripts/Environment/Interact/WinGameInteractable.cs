using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameInteractable : MonoBehaviour, IInteractable
{
    public bool DestroyAfterInteract { get; set; }

    public void Interact()
    {
        GameState.Instance.Win();
    }
}