using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveGenerator : MonoBehaviour
{
    public int seed;
    public bool randomSeed;

    [Range(0, 1)]
    public float fillChance;

    public int smoothRuns;

    public int width;
    public int height;

    private bool[,] grid;

    // For Tilemap
    public Tile wallTile;
    public Tilemap tilemap;
    public int cellSize = 1;

    void Start()
    {
        GenerateMap();

        DrawMap();
    }

    void GenerateMap()
    {
        InitGrid();

        for (int i = 0; i < smoothRuns; i++)
            SmoothMap();
    }

    void DrawMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y])
                {
                    Vector3Int currentCell = tilemap.WorldToCell(new Vector3((-width / 2) + x, (-height / 2) + y, 0));
                    tilemap.SetTile(currentCell, wallTile);
                }
            }
        }
    }

    void InitGrid()
    {
        System.Random rand;
        if (randomSeed)
            rand = new System.Random();
        else
            rand = new System.Random(seed);

        grid = new bool[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                grid[x, y] = ((float)(rand.NextDouble()) < fillChance);
    }

    void SmoothMap()
    {
        bool[,] newGrid = new bool[width, height];
        int neighbours;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    newGrid[x, y] = true;
                }
                else
                {
                    neighbours = GetNeighbours(x, y);

                    if (neighbours > 4)
                        newGrid[x, y] = true;
                    else if (neighbours < 4)
                        newGrid[x, y] = false;
                    else
                        newGrid[x, y] = grid[x, y];
                }
            }
        }

        grid = newGrid;
    }

    int GetNeighbours(int x, int y)
    { 
        int neighbours = 0;

        for (int neighbourX = x - 1; neighbourX < x + 2; neighbourX++)
            for (int neighbourY = y - 1; neighbourY < y + 2; neighbourY++)
                if (grid[neighbourX, neighbourY])
                    neighbours++;

        return neighbours;
    }
}
