using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    private Patrol _patrol;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }
}
