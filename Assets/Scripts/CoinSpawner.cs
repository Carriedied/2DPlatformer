using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Tilemap _groundTilemap;

    private List<Vector3> _availableCellsCoins;
    private List<bool> _isAvailableCell;
    private List<Coin> _spawnedCoins;

    private int _offsetY = 1;
    private int _coordinateZ = 0;
    private int numberOfCoins = 10;

    private void Awake()
    {
        _availableCellsCoins = new List<Vector3>();
        _isAvailableCell = new List<bool>();
        _spawnedCoins = new List<Coin>();
    }

    private void Start()
    {
        FindAvailableCells();
        FillAvailableCells();
    }

    private void FindAvailableCells()
    {
        BoundsInt bounds = _groundTilemap.cellBounds;
        Vector3Int position = new Vector3Int();
        Vector3Int upperPosition;
        Vector3 worldUpperPosition;

        for (int y = bounds.y; y < bounds.yMax; y++)
        {
            for (int x = bounds.x; x < bounds.xMax; x++)
            {
                position.x = x;
                position.y = y;
                position.z = _coordinateZ;

                if (_groundTilemap.GetTile(position) != null)
                {
                    upperPosition = position;
                    upperPosition.y += _offsetY;

                    if (_groundTilemap.GetTile(upperPosition) == null)
                    {
                        worldUpperPosition = _groundTilemap.GetCellCenterWorld(upperPosition);

                        _availableCellsCoins.Add(worldUpperPosition);
                        _isAvailableCell.Add(true);
                    }
                }
            }
        }
    }

    private void FillAvailableCells()
    {
        Coin coin;
        int minValue = 1;
        int index;
        int initialIndex = 0;
        int elementNearIndex = 1;
        int nextIndex;
        int previousIndex;

        for (int i = 0; i < numberOfCoins; i++)
        {
            index = UnityEngine.Random.Range(minValue, _availableCellsCoins.Count);

            nextIndex = index + elementNearIndex;
            previousIndex = index - elementNearIndex;

            if (previousIndex > initialIndex && nextIndex < _availableCellsCoins.Count)
            {
                if (_isAvailableCell[index] == true && _isAvailableCell[nextIndex] == true && _isAvailableCell[previousIndex] == true)
                {
                    coin = Instantiate(_coinPrefab, _availableCellsCoins[index], Quaternion.identity);

                    coin.OnCollected += RemoveCoin;

                    _spawnedCoins.Add(coin);

                    _isAvailableCell[index] = false;
                    _isAvailableCell[nextIndex] = false;
                    _isAvailableCell[previousIndex] = false;
                }
            }
        }
    }

    private void RemoveCoin(Coin coin)
    {
        int index = _spawnedCoins.IndexOf(coin);
        int elementNearIndex = 1;
        int nextIndex = index + elementNearIndex;
        int previousIndex = index - elementNearIndex;
        int initialIndex = 0;

        _availableCellsCoins.RemoveAt(index);

        if (previousIndex > initialIndex && nextIndex < _isAvailableCell.Count)
        {
            _isAvailableCell[index] = true;
            _isAvailableCell[nextIndex] = true;
            _isAvailableCell[previousIndex] = true;
        }  

        _spawnedCoins.Remove(coin);

        Destroy(coin.gameObject);
    }
}
