using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Generator : ScriptableObject
	{
		public int Width = 16;
		public int Height = 16;
		[Range(0, 1)]
		public float MixRoomFloorChance = .1f;
		[Range(0, 1)]
		public float RoomFloorChance = .333f;
		[Range(0, 1)]
		public float RoomWallChance = .333f;
	}
}
