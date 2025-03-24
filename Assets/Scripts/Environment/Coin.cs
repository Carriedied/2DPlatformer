using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> OnCollected;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
