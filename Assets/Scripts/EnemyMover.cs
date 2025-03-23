using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Transform _targetPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
    }

    public void TurnAround(int indexCurrentWaypoint)
    {
        float turnRight = 180;
        float turnLeft = 0;
        float _indexDeterminingRotation = 0;

        if (indexCurrentWaypoint == _indexDeterminingRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, turnRight, transform.rotation.z));
        }

        if (indexCurrentWaypoint > _indexDeterminingRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, turnLeft, transform.rotation.z));
        }
    }

}
