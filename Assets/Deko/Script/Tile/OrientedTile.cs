using ca.HenrySoftware.Deko;
namespace UnityEngine.Tilemaps
{
	public abstract class OrientedTile : TileBase
	{
		public TileOrientation Orientation;
		private bool FlipX => (Orientation & TileOrientation.FlipX) == TileOrientation.FlipX ? Utility.Random.NextBool() : false;
		private bool FlipY => (Orientation & TileOrientation.FlipY) == TileOrientation.FlipY ? Utility.Random.NextBool() : false;
		private bool Rot90 => (Orientation & TileOrientation.Rot90) == TileOrientation.Rot90 ? Utility.Random.NextBool() : false;
		private Matrix4x4 NextMatrix => Matrix4x4.TRS(Vector3.zero,
			Rot90 ? Quaternion.Euler(0, 0, -90f) : Quaternion.identity,
			new Vector3(FlipX ? -1f : 1f, FlipY ? -1f : 1f, 1f));
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			tileData.flags = TileFlags.LockTransform;
			tileData.transform = NextMatrix;
			base.GetTileData(position, tilemap, ref tileData);
		}
	}
}
