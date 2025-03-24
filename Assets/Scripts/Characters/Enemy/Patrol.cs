using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyMover))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private Flipper _flipper;
    private EnemyMover _enemyMover;

    private int _currentWaypoint = 0;
    private float _threshold = 0.2f;
    private Vector2 _movement;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        DefinitionPressure();

        _flipper.TurnAround(_movement.x);
    }

    private void Update()
    {
        if ((transform.position - _waypoints[_currentWaypoint].transform.position).sqrMagnitude < _threshold * _threshold)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            DefinitionPressure();

            _flipper.TurnAround(_movement.x);
        }
    }

    private void FixedUpdate()
    {
        _enemyMover.Move(_movement);
    }

    private void DefinitionPressure()
    {
        if (transform.position.x < _waypoints[_currentWaypoint].position.x)
        {
            _movement = Vector2.right;
        }
        else
        {
            _movement = Vector2.left;
        }
    }
}