using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

public class CellToNavmesh : MonoBehaviour
{
	public Transform surfaces;
	private const float WALKABLE_HEIGHT = 0.1f;
	private const float BLOCKING_HEIGHT = 2f;
	private Grid grid;
	private Tilemap map;
	// Use this for initialization
	void Start()
	{
		grid = GetComponent<Grid>();
		map = GetComponentInChildren<Tilemap>();

		InitColliders();

		BakeNavMesh();
	}
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
				surface.transform.position = GetActualPosition(pos);
				surface.transform.SetParent(surfaces);
			}
		}
	}

	private Vector3 GetActualPosition(Vector3Int pos)
	{
		Vector3 worldPos = map.CellToWorld(pos);
		Vector3 adjustment = grid.cellSize / 2;
		return worldPos + adjustment;
	}

	private void BakeNavMesh()
	{
		surfaces.transform.Rotate(90, 0, 0);
		foreach (NavMeshSurface s in surfaces.GetComponentsInChildren<NavMeshSurface>())
		{
			s.BuildNavMesh();
		}

		//surfaces.transform.rotation = Quaternion.Euler(0, 0f, 0f);
	}
}
