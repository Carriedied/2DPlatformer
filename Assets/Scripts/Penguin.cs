using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PenguinAnimator))]
[RequireComponent(typeof(WalletPenguin))]
public class Penguin : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;

    private Mover _mover;
    private InputReader _inputReader;
    private PenguinAnimator _playerAnimator;
    private WalletPenguin _purse;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PenguinAnimator>();
        _purse = GetComponent<WalletPenguin>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>();

        if (coin != null)
        {
            coin.Collect();
            _purse.AddCoin();
        }
    }
}
