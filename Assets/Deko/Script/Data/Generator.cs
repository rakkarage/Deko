using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Generator : ScriptableObject
	{
		public int WidthFixed = 8;
		[MinMaxSliderInt(1, 99)]
		public Vector2Int WidthAdd = new Vector2Int(1, 16);
		public int Width => WidthFixed + Utility.Random.Next(WidthAdd.x, WidthAdd.y);
		public int HeightFixed = 8;
		[MinMaxSliderInt(1, 99)]
		public Vector2Int HeightAdd = new Vector2Int(1, 16);
		public int Height => HeightFixed + Utility.Random.Next(HeightAdd.x, HeightAdd.y);
	}
}
