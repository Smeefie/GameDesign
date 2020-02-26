using UnityEngine;
using System.Collections;
using System;

public class DungeonGenerator : MonoBehaviour
{
	[Header("Dungeon Settings")]
	public int width = 50;
	public int height = 50;

	public string seed;
	public bool useRandomSeed = true;

	[Range(0, 100)]
	public int randomFillPercent = 42;

	public GameObject wallObj, floorObj;

	int[,] map;
	Vector2 roomSizeWorldUnits = new Vector2(1, 1);
	float worldUnitsInOneGridCell = 1;

	void Start()
	{
		GenerateMap();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GenerateMap();
		}
	}

	void GenerateMap()
	{
		map = new int[width, height];
		RandomFillMap();

		for (int i = 0; i < 5; i++)
		{
			SmoothMap();
		}

		if (map != null)
		{
			for (float x = 0; x < width * 0.16f; x += 0.16f)
			{
				for (float y = 0; y < height * 0.16f; y += 0.16f)
				{
					GameObject go = (map[(int)(x / 0.16f), (int)(y / 0.16f)] == 1) ? wallObj : floorObj;
					Spawn(x, y, go);
				}
			}
		}
	}


	void RandomFillMap()
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

	void SmoothMap()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				int neighbourWallTiles = GetSurroundingWallCount(x, y);

				if (neighbourWallTiles > 4)
					map[x, y] = 1;
				else if (neighbourWallTiles < 4)
					map[x, y] = 0;

			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY)
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

	void Spawn(float x, float y, GameObject toSpawn)
	{
		//find the position to spawn
		Vector2 offset = roomSizeWorldUnits / 2.0f;
		Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell - offset;

		//spawn object
		Instantiate(toSpawn, spawnPos, Quaternion.identity);
	}

}