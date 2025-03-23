using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsGround = false;
    }
}
