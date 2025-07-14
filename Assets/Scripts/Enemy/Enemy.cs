using UnityEngine;

[RequireComponent(typeof(SpawnerBulletEnemy))]
[RequireComponent(typeof(DetectorBulletPlayer))]
public class Enemy : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private SpawnerBulletEnemy _spawnerBulletEnemy;
    private DetectorBulletPlayer _detectorBulletPlayer;

    private void Awake()
    {
        _spawnerBulletEnemy = GetComponent<SpawnerBulletEnemy>();
        _detectorBulletPlayer = GetComponent<DetectorBulletPlayer>();
    }

    private void OnEnable()
    {
        _detectorBulletPlayer.Collided += PutObject;
    }

    private void OnDisable()
    {
        _detectorBulletPlayer.Collided -= PutObject;
    }

    public void Initialize(EnemyPool enemyPool, BulletPoolEnemy bulletPoolEnemy)
    {
        _enemyPool = enemyPool;
        _spawnerBulletEnemy.InitializePool(bulletPoolEnemy);
    }

    private void PutObject()
    {
        _enemyPool.PutObject(this);
    }
}