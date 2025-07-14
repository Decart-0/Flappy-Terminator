using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private BulletPoolEnemy _bulletPoolEnemy;
    [SerializeField] private BulletPoolPlayer _bulletPoolPlayer;

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.TryGetComponent(out BulletEnemy bulletEnemy))
        {
            _bulletPoolEnemy.PutObject(bulletEnemy);
        }

        if (collider.TryGetComponent(out BulletPlayer bulletPlayer))
        {
            _bulletPoolPlayer.PutObject(bulletPlayer);
        }
    }
}