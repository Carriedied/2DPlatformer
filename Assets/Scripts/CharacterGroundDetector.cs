using UnityEngine;

public class CharacterGroundDetector : MonoBehaviour
{
    public bool IsOnGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsOnGround = false;
    }
}
