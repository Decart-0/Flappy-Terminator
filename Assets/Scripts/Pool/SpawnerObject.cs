using UnityEngine;

abstract public class SpawnerObject<TObject, TPool> : MonoBehaviour
    where TObject : MonoBehaviour
    where TPool : ObjectPool<TObject>
{
    [SerializeField] protected TPool Pool;

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
        TObject obj = Pool.GetObject();
        
        obj.transform.position = _firePoint.position;
        obj.transform.rotation = _firePoint.rotation;
        obj.gameObject.SetActive(true);
    }

    private bool IsShootingAllowed(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _checkRadius, _obstacleLayers);

        return colliders.Length == 0;
    }
}