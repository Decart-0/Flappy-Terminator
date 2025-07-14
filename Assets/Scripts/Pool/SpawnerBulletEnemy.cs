using System.Collections;
using UnityEngine;

public class SpawnerBulletEnemy : SpawnerObject<BulletEnemy ,BulletPoolEnemy>
{
    [SerializeField] private float _delay = 1f;

    public void InitializePool(BulletPoolEnemy bulletPoolEnemy)
    {
        Pool = bulletPoolEnemy;
        StartGenerator();
    }

    private void StartGenerator()
    {
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        yield return wait;

        while (enabled)
        {
            TryShoot();

            yield return wait;
        }
    }
}