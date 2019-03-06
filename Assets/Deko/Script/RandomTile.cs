using ca.HenrySoftware.Deko;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	public class RandomTile : TileBase
	{
		public TileOrientation Orientation;
		public bool FlipX => (Orientation & TileOrientation.FlipX) == TileOrientation.FlipX ? Utility.Random.NextBool() : false;
		public bool FlipY => (Orientation & TileOrientation.FlipY) == TileOrientation.FlipY ? Utility.Random.NextBool() : false;
		public bool Rot90 => (Orientation & TileOrientation.Rot90) == TileOrientation.Rot90 ? Utility.Random.NextBool() : false;
		public static Quaternion RotateClockwise = Quaternion.Euler(0, 0, -90f);
		public static Quaternion RotateCounter = Quaternion.Euler(0, 0, 90f);
		public Matrix4x4 NextMatrix => Matrix4x4.TRS(Vector3.zero,
			Rot90 ? RotateClockwise : Quaternion.identity, new Vector3(FlipX ? -1f : 1f, FlipY ? -1f : 1f, 1f));
		public WeightedTile Tiles;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			Tiles.Next.GetTileData(position, tilemap, ref tileData);
			tileData.flags = TileFlags.LockTransform;
			tileData.transform = NextMatrix;
		}
	}
}
