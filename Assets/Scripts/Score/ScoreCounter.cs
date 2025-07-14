using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        DetectorBulletPlayer.Created += SubscribeToDetector;
    }

    private void OnDisable()
    {
        DetectorBulletPlayer.Created -= SubscribeToDetector;
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
 
    private void SubscribeToDetector(DetectorBulletPlayer detector)
    {
        detector.Collided += AddScore;
    }
}