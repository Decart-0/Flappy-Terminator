using UnityEngine;

public class InputScheme : MonoBehaviour
{
    [field: SerializeField] public KeyCode TakeOff { get; private set; } = KeyCode.Space;

    [field: SerializeField] public KeyCode Attack { get; private set; } = KeyCode.Q;
}