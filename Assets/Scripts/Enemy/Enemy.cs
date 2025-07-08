using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private ScoreCounter _scoreCounter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out BulletPlayer bulletPlayer)) 
        {
            _enemyPool.PutObject(gameObject.GetComponent<Enemy>());
            _scoreCounter.Add();
        }
    }

    public void Initialize(EnemyPool pool, ScoreCounter scoreCounter)
    {
        _enemyPool = pool;
        _scoreCounter = scoreCounter;
    }
}