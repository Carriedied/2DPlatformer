using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speedX;

    private Vector2 _movement;
    private Vector2 newPosition;

    private Rigidbody2D _physicalProperty;

    private void Awake()
    {
        _physicalProperty = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        _movement = direction.normalized * _speedX * Time.deltaTime;

        newPosition = _physicalProperty.position + _movement;

        _physicalProperty.MovePosition(newPosition);
    }
}
