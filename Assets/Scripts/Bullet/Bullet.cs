using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
abstract public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Color _color;
    [SerializeField] private Vector3 _movementDirection;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.color = _color;
    }

    private void Update()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }
}