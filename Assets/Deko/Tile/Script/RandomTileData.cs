using ca.HenrySoftware.Rage;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	[Serializable]
	public class RandomTileData : ScriptableObject
	{
		public TileOrientation orientation;
		public bool RandomBool => Random.value > .5f;
		public bool FlipX => (orientation & TileOrientation.FlipX) == TileOrientation.FlipX ? RandomBool : false;
		public bool FlipY => (orientation & TileOrientation.FlipY) == TileOrientation.FlipY ? RandomBool : false;
		public bool Rot90 => (orientation & TileOrientation.Rot90) == TileOrientation.Rot90 ? RandomBool : false;
		public static Quaternion RotateClockwise = Quaternion.Euler(0, 0, -90f);
		public static Quaternion RotateCounter = Quaternion.Euler(0, 0, 90f);
		public Matrix4x4 NextMatrix => Matrix4x4.TRS(Vector3.zero,
			Rot90 ? RotateClockwise : Quaternion.identity, new Vector3(FlipX ? -1f : 1f, FlipY ? -1f : 1f, 1f));
		public ProbabilityTile Tiles;
	}
}
