using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Blocking Tile", menuName = "Tiles/Blocking Tile")]
public class BlockingTile : TileBase
{
	public Sprite sprite;

	public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
	{
		tileData.sprite = sprite;
	}
}
