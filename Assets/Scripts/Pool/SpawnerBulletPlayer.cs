using UnityEngine;

[RequireComponent(typeof(InputScheme))]
public class SpawnerBulletPlayer : SpawnerObject<BulletPlayer, BulletPoolPlayer>
{
    private InputService _inputService;

    private void Awake()
    {
        _inputService = GetComponent<InputService>();
    }

    private void OnEnable()
    {
        _inputService.Attacked += TryShoot;
    }

    private void OnDisable()
    {
        _inputService.Attacked -= TryShoot;
    }
}