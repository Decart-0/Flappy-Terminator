using System;
using UnityEngine;

public class BirdCollisionHander : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        { 
            CollisionDetected?.Invoke(interactable);
        }
    }
}