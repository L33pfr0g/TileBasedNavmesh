using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

namespace TileBasedNavMesh
{
    public class CellToNavmesh : MonoBehaviour
    {
        public Transform surfaces;
        private const float WALKABLE_HEIGHT = 0.1f;
        private const float BLOCKING_HEIGHT = 2f;
        private Grid grid;
        private Tilemap map;
        // Use this for initialization
        public void Init()
        {
            grid = GetComponent<Grid>();
            map = GetComponentInChildren<Tilemap>();
            InitColliders();

            surfaces.GetComponent<NavMeshSurface>().BuildNavMesh();
        }

        //Create a collider for each tile. Height is based on wether it's a Walkable Tile or a Blocking Tile
        private void InitColliders()
        {
            for (int x = map.origin.x; x < map.size.x; x++)
            {
                for (int y = map.origin.y; y < map.size.y; y++)
                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    float height = 0;
                    TileBase tile = map.GetTile(pos);
                    if (tile is WalkableTile)
                    {
                        height = WALKABLE_HEIGHT;
                    }
                    else if (tile is BlockingTile)
                    {
                        height = BLOCKING_HEIGHT;
                    }
                    else
                    {
                        continue;
                    }
                    GameObject surface = new GameObject("surface");
                    surface.AddComponent<BoxCollider>();
                    surface.AddComponent<NavMeshSurface>();
                    surface.GetComponent<NavMeshSurface>().useGeometry = NavMeshCollectGeometry.PhysicsColliders;
                    BoxCollider col = surface.GetComponent<BoxCollider>();
                    col.size = new Vector3(grid.cellSize.x, grid.cellSize.y, height);
                    surface.transform.position = map.GetCellCenterWorld(pos);
                    surface.transform.SetParent(surfaces);
                }
            }
        }
    }
}

