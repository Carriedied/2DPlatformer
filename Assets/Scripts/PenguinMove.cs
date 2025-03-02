using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PenguinAnimator))]
public class PenguinMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CharacterGroundDetector _groundDetector;

    private Rigidbody2D _physicalProperty;
    private PenguinAnimator _playerAnimator;

    private float _indexDeterminingRotation = 0;
    private float _movement;

    private void Awake()
    {
        _physicalProperty = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PenguinAnimator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _movement = Input.GetAxis("Horizontal");

            HorizontalMove(_movement);

            TurnAround(_movement);

            _playerAnimator.RunAnimation(true);
        }
        else
        {
            _playerAnimator.RunAnimation(false);
        }

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(_physicalProperty.linearVelocity.y) < 0.02 && _groundDetector.IsOnGround)
        {
            Jump();
        }
    }

    private void TurnAround(float movement)
    {
        Quaternion degreeRotation = transform.rotation;

        if (movement > _indexDeterminingRotation)
        {
            degreeRotation.y = 0;

            transform.rotation = degreeRotation;
        }

        if (movement < _indexDeterminingRotation)
        {
            degreeRotation.y = 180;

            transform.rotation = degreeRotation;
        }
    }

    private void HorizontalMove(float movement)
    {
        transform.position += new Vector3(movement, 0, 0) * _speed * Time.deltaTime;
    }

    private void Jump()
    {
        _physicalProperty.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}
