using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputService))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private InputService _inputService;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputService = GetComponent<InputService>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _inputService.TookOff += TakeOff;
    }

    private void OnDisable()
    {
        _inputService.TookOff -= TakeOff;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void TakeOff() 
    {
        _rigidbody2D.linearVelocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }
}