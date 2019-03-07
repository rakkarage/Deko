using ca.HenrySoftware.Deko;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	public class RandomTile : OrientedTile
	{
		public WeightedSprite Sprites;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			tileData.sprite = Sprites.Next;
			base.GetTileData(position, tilemap, ref tileData);
		}
	}
}
