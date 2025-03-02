using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _coinPrefab;
    [SerializeField] private int _numberOfCoins = 10;
    [SerializeField] private Tilemap _groundTilemap;

    private HashSet<Vector3> _occupiedPositions = new HashSet<Vector3>();
    private float _coinOffsetY = 0.75f;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _numberOfCoins; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            while (_occupiedPositions.Contains(spawnPosition) || spawnPosition == Vector3.zero || IsPositionOccupied(spawnPosition))
            {
                spawnPosition = GetRandomSpawnPosition();
            }

            _occupiedPositions.Add(spawnPosition);

            Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        BoundsInt bounds = _groundTilemap.cellBounds;

        int randomX = Random.Range(bounds.x, bounds.x + bounds.size.x);
        int randomY = Random.Range(bounds.y, bounds.y + bounds.size.y);
        int randomZ = 0;

        Vector3Int cellPosition = new Vector3Int(randomX, randomY, randomZ);

        TileBase tile = _groundTilemap.GetTile(cellPosition);

        if (tile != null)
        {
            return _groundTilemap.GetCellCenterWorld(cellPosition) + new Vector3(0, _coinOffsetY, 0); // Увеличьте смещение по Y
        }

        return Vector3.zero;
    }

    private bool IsPositionOccupied(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, 0.1f);

        return hit != null;
    }
}
