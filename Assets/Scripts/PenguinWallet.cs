using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinWallet : MonoBehaviour
{
    public static PenguinWallet Instance;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;

        Debug.Log("Score: " + _score);
    }
}
