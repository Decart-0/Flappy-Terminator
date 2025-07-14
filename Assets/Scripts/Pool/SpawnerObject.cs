using UnityEngine;

abstract public class SpawnerObject<Object, ObjectPool> : MonoBehaviour
    where Object : MonoBehaviour
    where ObjectPool : ObjectPool<Object>
{
    [SerializeField] protected ObjectPool Pool;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private LayerMask _obstacleLayers;

    [SerializeField] private float _speed;
    [SerializeField] private float _checkRadius = 0.5f;

    protected void TryShoot()
    {
        if (IsShootingAllowed(_firePoint.position))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Object obj = Pool.GetObject();
        
        obj.transform.position = _firePoint.position;
        obj.transform.rotation = _firePoint.rotation;

        obj.gameObject.SetActive(true);

        if (obj.TryGetComponent(out Rigidbody2D rb))
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