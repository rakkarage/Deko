using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Config : ScriptableObject
	{
		public WeightedTheme Themes;
		public Theme Theme;
		public WeightedLightTheme LightThemes;
		public LightTheme LightTheme;
		public WeightedGenerator Generators;
		public Generator Generator;
		[Range(0, 1)]
		public float AllRoomFloorChance = .1f;
		public bool AllRoomFloor;
		[Range(0, 1)]
		public float MixRoomFloorChance = .1f;
		public bool MixRoomFloor;
		[Range(0, 1)]
		public float DefaultOrientationChance = .1f;
		[Range(0, 1)]
		public float RoomFloorChance = .1f;
		public bool RoomFloor => Utility.Random.NextPercent(RoomFloorChance);
		[Range(0, 1)]
		public float RoomWallChance = .1f;
		public bool RoomWall => Utility.Random.NextPercent(RoomWallChance);
		[Range(0, 1)]
		public float WallTorchChance = .1f;
		public bool WallTorch => Utility.Random.NextPercent(WallTorchChance);
		[ContextMenu("Roll")]
		public void Roll()
		{
			Theme = Themes.Next;
			LightTheme = LightThemes.Next;
			Generator = Generators.Next;
			MixRoomFloor = Utility.Random.NextPercent(MixRoomFloorChance);
			AllRoomFloor = Utility.Random.NextPercent(AllRoomFloorChance);
			OrientedTile.Apply = Utility.Random.NextPercent(DefaultOrientationChance);
		}
	}
}
