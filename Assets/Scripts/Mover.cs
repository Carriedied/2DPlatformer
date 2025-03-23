using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForceY;

    private Rigidbody2D _physicalProperty;
    private float _jumpForceX = 0;
    private float _offsetY = 0;
    private float _offsetZ = 0;
    private float _indexDeterminingRotation = 0;
    private float _rotationRight = 0;
    private float _rotationLeft = 180;

    private void Awake()
    {
        _physicalProperty = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        transform.position += new Vector3(direction, _offsetY, _offsetZ) * _speedX * Time.deltaTime;

        TurnAround(direction);
    }

    public void Jump()
    {
        _physicalProperty.AddForce(new Vector2(_jumpForceX, _jumpForceY), ForceMode2D.Impulse);
    }

    private void TurnAround(float movement)
    {
        Quaternion degreeRotation = transform.rotation;

        if (movement > _indexDeterminingRotation)
        {
            degreeRotation.y = _rotationRight;

            transform.rotation = degreeRotation;
        }

        if (movement < _indexDeterminingRotation)
        {
            degreeRotation.y = _rotationLeft;

            transform.rotation = degreeRotation;
        }
    }
}
