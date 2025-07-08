using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _checkRadius;

    [SerializeField] private EnemyPool _pool;
    [SerializeField] private BulletPool _bulletPool;

    public void StartGenerator()
    {
        StartCoroutine(GeneratePipes());
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        if (IsPositionFree(spawnPoint))
        {
            Enemy enemy = _pool.GetObject();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            enemy.GetComponent<BulletGenerator>().InitializePool(_bulletPool);
        }
    }

    private bool IsPositionFree(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _checkRadius);

        if (colliders.Length > 0) 
        { 
            return false;
        }

        return true;
    }

    private IEnumerator GeneratePipes()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }
}