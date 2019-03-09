using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Config : ScriptableObject
	{
		public WeightedTheme Themes;
		public Theme Theme;
		public WeightedGenerator Generators;
		public Generator Generator;
		public WeightedLightTile LightTiles;
		public LightTile LightTile;
		[Range(0, 1)]
		public float AllRoomFloorChance = .01f;
		public bool AllRoomFloor;
		[Range(0, 1)]
		public float MixRoomFloorChance = .1f;
		public bool MixRoomFloor;
		[Range(0, 1)]
		public float RoomFloorChance = .333f;
		public bool RoomFloor => Utility.Random.NextPercent(RoomFloorChance);
		[Range(0, 1)]
		public float RoomWallChance = .333f;
		public bool RoomWall => Utility.Random.NextPercent(RoomWallChance);
		[Range(0, 1)]
		public float WallTorchChance = .333f;
		public bool WallTorch => Utility.Random.NextPercent(WallTorchChance);
		[ContextMenu("Roll")]
		public void Roll()
		{
			Theme = Themes.Next;
			Generator = Generators.Next;
			LightTile = LightTiles.Next;
			MixRoomFloor = Utility.Random.NextPercent(MixRoomFloorChance);
			AllRoomFloor = Utility.Random.NextPercent(AllRoomFloorChance);
		}
	}
}
