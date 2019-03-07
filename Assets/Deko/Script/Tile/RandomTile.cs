using ca.HenrySoftware.Deko;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	public class RandomTile : OrientedTile
	{
		public WeightedTile Tiles;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			base.GetTileData(position, tilemap, ref tileData);
		}
	}
}
