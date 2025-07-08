using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private BulletPoolPlayer _bulletPoolPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.TryGetComponent(out BulletEnemy bullet))
        {
            _bulletPool.PutObject(bullet);
        }

        if (other.TryGetComponent(out BulletPlayer bulletPlayer))
        {
            _bulletPoolPlayer.PutObject(bulletPlayer);
        }
    }
}