using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    public const KeyCode JumpKey = KeyCode.Space;

    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKey(KeyCode.Space))
            _isJump = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
