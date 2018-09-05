using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Tilemaps;

[Serializable]
[CreateAssetMenu(fileName = "New Walkable Tile", menuName = "Tiles/Walkable Tile")]
public class WalkableTile : TileBase
{
	public Sprite sprite;
	public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
	{
		tileData.sprite = sprite;
	}
}
