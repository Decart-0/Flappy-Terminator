using UnityEngine;

abstract public class PoolGenerator<T, U> : MonoBehaviour
    where T : MonoBehaviour
    where U : ObjectPool<T>
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _checkRadius = 0.5f;
    [SerializeField] protected U Pool;
    [SerializeField] private LayerMask _obstacleLayers;

    protected void TryShoot()
    {
        if (IsShootingAllowed(_firePoint.position))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        T obj = Pool.GetObject();
        obj.gameObject.SetActive(true);
        obj.transform.position = _firePoint.position;

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = _firePoint.right * _speed;
        }
    }

    private bool IsShootingAllowed(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _checkRadius, _obstacleLayers);

        return colliders.Length == 0;
    }
}