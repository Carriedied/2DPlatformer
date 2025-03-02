using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private int _startIndexWaypoint = 0;
    private int _endIndexWaypoint = 1;
    private float _threshold = 0.1f;
    private float _indexDeterminingRotation = 0;

    private void Update()
    {
        Run(_waypoints[_currentWaypoint]);

        if ((transform.position - _waypoints[_currentWaypoint].transform.position).sqrMagnitude < _threshold * _threshold && _currentWaypoint == _startIndexWaypoint)
        {
            _currentWaypoint++;
        }
        else if ((transform.position - _waypoints[_currentWaypoint].transform.position).sqrMagnitude < _threshold * _threshold && _currentWaypoint == _endIndexWaypoint)
        {
            _currentWaypoint--;
        }

        TurnAround();
    }

    private void TurnAround()
    {
        float turnRight = 180;
        float turnLeft = 0;

        if (_currentWaypoint == _indexDeterminingRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, turnRight, transform.rotation.z));
        }

        if (_currentWaypoint > _indexDeterminingRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, turnLeft, transform.rotation.z));
        }
    }

    private void Run(Transform _targetPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
    }
}
