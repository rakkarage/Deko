using System;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Theme : ScriptableObject
	{
		public TileBase FloorSimple;
		public TileBase FloorRoom;
		public TileBase StairDown;
		public TileBase StairUp;
		public TileBase DoorShut;
		public TileBase DoorOpen;
		public TileBase DoorBroke;
		public TileBase Torch;
		public TileBase WallSimple;
		public TileBase WallRoom;
	}
}
