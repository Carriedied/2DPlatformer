using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AvailableCells))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private AvailableCells _availableCells;
    private int _countCorrectCells;
    private int _numberCoins = 10;

    private void Awake()
    {
        _availableCells = GetComponent<AvailableCells>();
    }

    private void Start()
    {
        GetCorrectCellsCount();
        SpawnCoins();
    }

    private void GetCorrectCellsCount()
    {
        _countCorrectCells = _availableCells.CountCorrectCells();
    }

    private void SpawnCoins()
    {
        Coin coin;
        Vector3 positionCorrectCell;
        int minValue = 1;
        int index;
        int initialIndex = 0;
        int elementNearIndex = 1;
        int nextIndex;
        int previousIndex;
        int countDeleteCells = 3;

        for (int i = 0; i < _numberCoins; i++)
        {
            index = UnityEngine.Random.Range(minValue, _countCorrectCells);

            nextIndex = index + elementNearIndex;
            previousIndex = index - elementNearIndex;

            if (previousIndex > initialIndex && nextIndex < _countCorrectCells)
            {
                positionCorrectCell = _availableCells.GetCoordinateCorrectCell(index);

                coin = Instantiate(_coinPrefab, positionCorrectCell, Quaternion.identity);

                coin.OnCollected += RemoveCoin;

                _availableCells.RemoveCorrectCells(nextIndex);
                _availableCells.RemoveCorrectCells(index);
                _availableCells.RemoveCorrectCells(previousIndex);

                _countCorrectCells -= countDeleteCells;
            }
        }
    }

    private void RemoveCoin(Coin coin)
    {
        Destroy(coin.gameObject);

        coin.OnCollected -= RemoveCoin;
    }
}
