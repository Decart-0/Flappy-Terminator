using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisionHander))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHander _birdCollisionHander;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdCollisionHander = GetComponent<BirdCollisionHander>();
    }

    private void OnEnable()
    {
        _birdCollisionHander.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHander.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _birdMover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable) 
    {
        GameOver?.Invoke();
    }
}