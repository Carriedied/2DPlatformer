using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(WalletPenguin))]
public class PenguinCollector : MonoBehaviour
{
    private WalletPenguin _purse;

    private void Awake()
    {
        _purse = GetComponent<WalletPenguin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _purse.AddCoin();
        }
    }
}
