using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Tilemaps;
using UnityEditor;
using MyBox;

[Serializable]
public class RoomGenerator : MonoBehaviour
{
	//[Header("Room Transform Settings")]
	//public Vector3Int position = new Vector3Int(13, 13, 0);
	//public Vector3Int scale = new Vector3Int(26, 26, 0);

	[Header("Room Generation Settings")]
	public bool useRandomSeed = true;

	[ConditionalField("useRandomSeed", true)] 
	public string seed;

	[Range(0, 100)]
	public int randomFillPercent = 70;

	[Header("Dungeon Tiles")]
	public Tilemap FloorTilemap;
	public Tilemap WallTilemap;
	public TileBase FloorTile;
	public TileBase WallTile;

	private int[,] map;
	private float worldUnitsInOneGridCell = 1;
	private int borderThickness = 2;

	public void DeleteMap()
	{
		FloorTilemap.ClearAllTiles();
		WallTilemap.ClearAllTiles();
	}

	public void GenerateRoom(int xOffset, int yOffset, int widht, int height)
	{
		Vector3Int position = new Vector3Int((int)xOffset, (int)yOffset, 0);
		Vector3Int scale = new Vector3Int((int)widht, (int)height, 0);

		//DeleteMap();

		map = new int[scale.x, scale.y];
		RandomFillMap(scale);

		for (int i = 0; i < 5; i++)
		{
			ApplyCellular(scale);
		}

		if (map != null)
		{
			for (int x = 0; x < scale.x; x++)
			{
				for (int y = 0; y < scale.y; y++)
				{
					if(map[x, y] == 0)
					{
						CreateTile(x + position.x, y + position.y, WallTilemap, WallTile);
					}
					else
					{
						CreateTile(x + position.x, y + position.y, FloorTilemap, FloorTile);
					}
				}
			}
		}
	}

	private void RandomFillMap(Vector3Int scale)
	{
		if (useRandomSeed)
		{
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < scale.x; x++)
		{
			for (int y = 0; y < scale.y; y++)
			{
				if (x <= borderThickness || x >= scale.x - 1 - borderThickness || y <= borderThickness || y >= scale.y - 1 - borderThickness )
				{
					map[x, y] = 0;
				}
				else
				{
					map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
				}
			}
		}
	}

	private void ApplyCellular(Vector3Int scale)
	{
		for (int x = 0; x < scale.x; x++)
		{
			for (int y = 0; y < scale.y; y++)
			{
				int neighbourWallTiles = GetSurroundingWallCount(x, y, scale);

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

	private int GetSurroundingWallCount(int gridX, int gridY, Vector3Int scale)
	{
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
		{
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
			{
				if (neighbourX >= 0 && neighbourX < scale.x && neighbourY >= 0 && neighbourY < scale.y)
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
		Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell;

		toMap.SetTile(new Vector3Int((int)spawnPos.x, (int)spawnPos.y, 0), toSpawn);
	}
}
