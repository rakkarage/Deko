using System;
namespace UnityEngine.Tilemaps
{
	[CreateAssetMenu]
	public class AnimatedTile : OrientedTile
	{
		public Sprite[] Sprites;
		public bool RandomStartTime = true;
		[MinMaxSlider(1, 10)]
		public Vector2 Speed = Vector2.one;
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			if (Sprites?.Length > 0)
				tileData.sprite = Sprites[RandomStartTime ? Random.Range(0, Sprites.Length) : 0];
			base.GetTileData(position, tilemap, ref tileData);
		}
		public override bool GetTileAnimationData(Vector3Int position, ITilemap tileMap, ref TileAnimationData tileAnimationData)
		{
			if (Sprites?.Length == 0)
				return false;
			tileAnimationData.animatedSprites = Sprites;
			tileAnimationData.animationSpeed = Random.Range(Speed.x, Speed.y);
			tileAnimationData.animationStartTime = RandomStartTime ? Random.value : 0;
			return true;
		}
	}
}
