using UnityEngine;

abstract public class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected Color _color;

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
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}