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
	private System.Random rand = new System.Random();

	public void GenerateRoom(int xOffset, int yOffset, int width, int height, int customSeed)
	{
		Vector3Int position = new Vector3Int(xOffset, yOffset, 0);
		Vector3Int scale = new Vector3Int(width, height, 0);

		//DeleteMap();

		map = new int[scale.x, scale.y];
		RandomFillMap(scale, customSeed);

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
					if (map[x, y] == 0)
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

		RemoveCorners(xOffset, yOffset, width, height);
	}

	private void RemoveCorners(int xOffset, int yOffset, int width, int height)
	{
		var pos = new Vector3Int(xOffset, yOffset, 0);
		FloorTilemap.SetTile(pos, null);
		WallTilemap.SetTile(pos, WallTile);
		
		pos = new Vector3Int(xOffset + width - 1, yOffset, 0);
		FloorTilemap.SetTile(pos, null);
		WallTilemap.SetTile(pos, WallTile);
		
		pos = new Vector3Int(xOffset, yOffset + height - 1, 0);
		FloorTilemap.SetTile(pos, null);
		WallTilemap.SetTile(pos, WallTile);
		
		pos = new Vector3Int(xOffset + width - 1, yOffset + height - 1, 0);
		FloorTilemap.SetTile(pos, null);
		WallTilemap.SetTile(pos, WallTile);
	}

	public void DeleteMap()
	{
		FloorTilemap.ClearAllTiles();
		WallTilemap.ClearAllTiles();
	}

	private void RandomFillMap(Vector3Int scale, int customSeed)
	{
		if (useRandomSeed || customSeed != -1)
		{
			seed = rand.Next(0, 2000).ToString();
		}
		else
		{
			seed = customSeed.ToString();
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
