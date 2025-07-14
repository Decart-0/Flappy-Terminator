using System;
using UnityEngine;

[RequireComponent(typeof(InputScheme))]
public class InputService : MonoBehaviour
{
    private InputScheme _inputScheme;

    public event Action Attacked;
    public event Action TookOff;

    private void Awake()
    {
        _inputScheme = GetComponent<InputScheme>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inputScheme.Attack)) 
        {
            Attacked?.Invoke();
        }

        if (Input.GetKeyDown(_inputScheme.TakeOff))
        {
            TookOff?.Invoke();
        }
    }
}