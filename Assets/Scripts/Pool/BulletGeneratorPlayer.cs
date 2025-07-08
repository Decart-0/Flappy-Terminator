using UnityEngine;

public class BulletGeneratorPlayer : PoolGenerator<BulletPlayer, BulletPoolPlayer>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            TryShoot();
        }    
    }
}