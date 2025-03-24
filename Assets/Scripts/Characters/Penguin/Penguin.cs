using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PenguinAnimator))]
public class Penguin : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;

    private Mover _mover;
    private InputReader _inputReader;
    private PenguinAnimator _playerAnimator;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PenguinAnimator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
            _playerAnimator.RunAnimation(true);
        }
        else
        {
            _playerAnimator.RunAnimation(false);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();
    }
}
