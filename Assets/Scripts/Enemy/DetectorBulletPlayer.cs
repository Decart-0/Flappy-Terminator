using System;
using UnityEngine;

public class DetectorBulletPlayer : MonoBehaviour
{
    private ScoreCounter _scoreCounter;

    public event Action OnDestroyed;
    public event Action Collided;

    private void Awake()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _scoreCounter?.RegisterDetector(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out BulletPlayer bulletPlayer))
        {
            Collided?.Invoke();
        }
    }

    public void OnDestroy()
    {
        OnDestroyed?.Invoke();
        OnDestroyed = null;
        Collided = null;
    }
}