using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private EnemyMover _mover;

    private int _currentWaypoint = 0;
    private int _startIndexWaypoint = 0;
    private int _endIndexWaypoint = 1;
    private float _threshold = 0.2f;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        if ((transform.position - _waypoints[_currentWaypoint].transform.position).sqrMagnitude < _threshold * _threshold && _currentWaypoint == _startIndexWaypoint)
        {
            _currentWaypoint++;
        }
        else if ((transform.position - _waypoints[_currentWaypoint].transform.position).sqrMagnitude < _threshold * _threshold && _currentWaypoint == _endIndexWaypoint)
        {
            _currentWaypoint--;
        }
    }

    private void FixedUpdate()
    {
        _mover.Move(_waypoints[_currentWaypoint]);
        _mover.TurnAround(_currentWaypoint);
    }
}