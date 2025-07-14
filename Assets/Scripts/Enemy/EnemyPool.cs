using UnityEngine;

[RequireComponent(typeof(BulletPoolEnemy))]
public class EnemyPool : ObjectPool<Enemy> 
{
    private BulletPoolEnemy _bulletPoolEnemy;

    private void Awake()
    {
        _bulletPoolEnemy = GetComponent<BulletPoolEnemy>();
    }

    public override Enemy GetObject()
    {
        Enemy enemy = base.GetObject();
        enemy.Initialize(this, _bulletPoolEnemy);

        return enemy;
    }
}