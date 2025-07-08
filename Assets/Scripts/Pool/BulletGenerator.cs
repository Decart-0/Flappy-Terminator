using System.Collections;
using UnityEngine;

public class BulletGenerator : PoolGenerator<BulletEnemy ,BulletPool>
{
    [SerializeField] private float _delay = 1f;

    public void InitializePool(BulletPool pool)
    {
        Pool = pool;
        StartGenerator();
    }

    private void StartGenerator()
    {
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            TryShoot();

            yield return wait;
        }
    }
}