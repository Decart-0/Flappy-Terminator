using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void RegisterDetector(DetectorBulletPlayer detectorBulletPlayer) 
    {
        if (detectorBulletPlayer == null) return;

        detectorBulletPlayer.Collided += AddScore;
        detectorBulletPlayer.OnDestroyed += () => detectorBulletPlayer.Collided -= AddScore;
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}