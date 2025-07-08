using UnityEngine;

public class EnemyPool : ObjectPool<Enemy> 
{
    [SerializeField] private ScoreCounter _scoreCounter;

    public override Enemy GetObject()
    {
        Enemy enemy = base.GetObject();
        enemy.Initialize(this, _scoreCounter);

        return enemy;
    }
}