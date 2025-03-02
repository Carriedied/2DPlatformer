using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PenguinWallet.Instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}
