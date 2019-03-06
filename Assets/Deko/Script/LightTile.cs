using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class LightTile : TileBase
	{
		public Sprite[] Sprites;
		public int Level;
		public bool Explored;
	}
}
