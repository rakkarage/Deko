using System;
using UnityEditor.Tilemaps;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	public class RandomTile : TileBase
	{
		public RandomTileData Data;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			Data.Tiles.Next.GetTileData(position, tilemap, ref tileData);
			tileData.flags = TileFlags.LockTransform;
			tileData.transform = Data.NextMatrix;
		}
	}
}
