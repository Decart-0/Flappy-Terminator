using UnityEngine;

public class BulletPlayer : Bullet
{
    private void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}