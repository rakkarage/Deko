using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class LightTile : TileBase
	{
		public int Level;
		private int _levelExplored = 7;
		public Sprite[] Levels;
		public bool Explored => Level > _levelExplored;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			tileData.sprite = Levels[Level];
		}
	}
}
