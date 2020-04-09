﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [Header("Floor Settings")]
    public int HorizontalRooms = 2;
    public int VerticalRooms = 2;
    public int RoomWidth = 26;
    public int RoomHeight = 26;

    private RoomGenerator roomGenerator;
    void Start()
    {
        roomGenerator = GetComponent<RoomGenerator>();

        GenerateFloor(HorizontalRooms, VerticalRooms, RoomWidth, RoomHeight);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            roomGenerator.DeleteMap();
            GenerateFloor(HorizontalRooms, VerticalRooms, RoomWidth, RoomHeight);
        }
    }

    private void GenerateFloor(int hor, int ver, int width, int height)
    {
        for (int x = 0; x < hor; x++)
        {
            for (int y = 0; y < ver; y++)
            {
                roomGenerator.GenerateRoom(x * width, y * height, width, height);
            }
        }
    }
}