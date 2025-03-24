using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Tilemap>(out _))
            IsGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsGround = false;
    }
}
