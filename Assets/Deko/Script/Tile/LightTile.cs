using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class LightTile : TileBase
	{
		public Sprite[] Levels;
		public int Level;
		// public bool Explored;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			tileData.sprite = Levels[Level];
		}
	}
}
