using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateAssets : MonoBehaviour
{
    private float worldUnitsInOneGridCell = 1;
    private System.Random rand;

    public int mapWidth = 1;
    public int mapHeight = 1;

    [Header("CheckForFloor")]
    public Tilemap FloorTilemap;
    public TileBase FloorTile;

    [Header("Asset Prefabs")]
    public GameObject Grass;
    public GameObject RockBig;

    public GameObject[] SmallRocks;
    

    private void Start()
    {
        rand = new System.Random();
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if(FloorTilemap.GetTile(new Vector3Int(x, y, 0)) == FloorTile)
                {
                    if (rand.Next(0, 100) < 20)
                    {
                        Instantiate(Grass, new Vector3(x * .16f, y * .16f, 0f), new Quaternion());         
                    }
                    else if (rand.Next(0, 100) < 4)
                    {
                        var GO = SmallRocks[rand.Next(0, SmallRocks.Length)];
                        Instantiate(GO, new Vector3(x * .16f, y * .16f, 0f), new Quaternion());
                    }
                    else if (rand.Next(0, 100) < 4)
                    {
                        Instantiate(RockBig, new Vector3(x * .16f, y * .16f, 0f), new Quaternion());
                    }
                }               
            }
        }
    }

    private void CreateTile(float x, float y, Tilemap toMap, TileBase toSpawn)
    {
        Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell;

        toMap.SetTile(new Vector3Int((int)spawnPos.x, (int)spawnPos.y, 0), toSpawn);
    }
}
