using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{
	[Header("Dungeon Settings")]
	public int width = 50;
	public int height = 50;

	public string seed;
	public bool useRandomSeed = true;

	[Range(0, 100)]
	public int randomFillPercent = 42;

	[Header("Dungeon Tiles")]
	public Tilemap FloorTilemap;
	public Tilemap WallTilemap;
	public TileBase FloorTile;
	public TileBase WallTile;

	private int[,] map;
	private Vector2 roomSizeWorldUnits;
	private float worldUnitsInOneGridCell = 1;

	private void Start()
	{
		roomSizeWorldUnits = new Vector2(width / 2, height / 2);
		GenerateMap();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GenerateMap();
		}
	}

	private void DeleteMap()
	{
		FloorTilemap.ClearAllTiles();
		WallTilemap.ClearAllTiles();
	}

	private void GenerateMap()
	{
		DeleteMap();

		map = new int[width, height];
		RandomFillMap();

		for (int i = 0; i < 5; i++)
		{
			ApplyCellular();
		}

		if (map != null)
		{
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					if(map[x, y] == 1)
					{
						CreateTile(x, y, WallTilemap, WallTile);
					}
					else
					{
						CreateTile(x, y, FloorTilemap, FloorTile);
					}
				}
			}
		}
	}

	private void RandomFillMap()
	{
		if (useRandomSeed)
		{
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
				{
					map[x, y] = 1;
				}
				else
				{
					map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
				}
			}
		}
	}

	private void ApplyCellular()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				int neighbourWallTiles = GetSurroundingWallCount(x, y);

				if (neighbourWallTiles > 4)
				{
					map[x, y] = 1;
				}

				else if (neighbourWallTiles < 4)
				{
					map[x, y] = 0;
				}
			}
		}
	}

	private int GetSurroundingWallCount(int gridX, int gridY)
	{
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
		{
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
			{
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
				{
					if (neighbourX != gridX || neighbourY != gridY)
					{
						wallCount += map[neighbourX, neighbourY];
					}
				}
				else
				{
					wallCount++;
				}
			}
		}

		return wallCount;
	}

	private void CreateTile(float x, float y, Tilemap toMap, TileBase toSpawn)
	{
		Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell - (roomSizeWorldUnits / 2.0f);

		toMap.SetTile(new Vector3Int((int)spawnPos.x, (int)spawnPos.y, 0), toSpawn);
	}
}