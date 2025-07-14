using System;
using UnityEngine;

public class DetectorBulletPlayer : MonoBehaviour
{
    public static event Action<DetectorBulletPlayer> Created;

    public event Action Collided;

    private void Awake()
    {
        Created?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out BulletPlayer bulletPlayer))
        {
            Collided?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Created = null;
    }
}