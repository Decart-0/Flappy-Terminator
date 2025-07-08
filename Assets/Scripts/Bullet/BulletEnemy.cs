using UnityEngine;

public class BulletEnemy : Bullet, IInteractable
{
    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}