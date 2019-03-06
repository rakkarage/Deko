using System;
namespace UnityEngine.Tilemaps
{
	[Flags]
	public enum TileOrientation
	{
		None = 0,
		FlipX = 1,
		FlipY = 2,
		Rot90 = 4,
	}
}
