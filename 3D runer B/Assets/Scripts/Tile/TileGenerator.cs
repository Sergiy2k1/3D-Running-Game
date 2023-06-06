using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPosition = 537;
    private float tileLenght = 500;

    [SerializeField] private Transform player;
    private int startTiles = 2;

    private void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(3);
            }
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void Update()
    {
        if (player.position.z +390 > spawnPosition - (startTiles * tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPosition, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPosition += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
