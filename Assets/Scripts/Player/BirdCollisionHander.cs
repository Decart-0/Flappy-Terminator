using System;
using UnityEngine;

public class BirdCollisionHander : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IInteractable interactable))
        { 
            CollisionDetected?.Invoke(interactable);
        }
    }
}