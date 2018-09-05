using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellToNavmesh : MonoBehaviour
{

    private Grid grid;
    private Tilemap map;
    // Use this for initialization
    void Start()
    {
        grid = GetComponent<Grid>();
        map = GetComponentInChildren<Tilemap>();

        InitColliders();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitColliders()
    {
        for (int x = map.origin.x; x < map.size.x; x++)
        {
            for (int y = map.origin.y; y < map.size.y; y++)
            {
                Debug.Log(String.Format("({0},{1},0) : {2}", x, y, map.GetTile(new Vector3Int(x, y, 0))));

            }
        }
    }
}
