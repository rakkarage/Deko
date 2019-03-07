using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class LightTile : TileBase
	{
		public LightTheme Theme;
		public int Level;
		public bool Explored;
	}
}
