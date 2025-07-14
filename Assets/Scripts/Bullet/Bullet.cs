using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
abstract public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Color _color;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _movementDirection = Vector3.right;

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        _spriteRenderer.color = _color;
    }

    private void Update()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }

    protected virtual void OnAwake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}