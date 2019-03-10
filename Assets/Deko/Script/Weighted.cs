using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[Serializable]
	public class WeightedTile : Weighted<TileBase> { }
	[Serializable]
	public class WeightedTheme : Weighted<Theme> { }
	[Serializable]
	public class WeightedLightTheme : Weighted<LightTheme> { }
	[Serializable]
	public class WeightedGenerator : Weighted<Generator> { }
	[Serializable]
	public abstract class Weighted<T>
	{
		public T[] Items;
		public int[] Weights;
		public T Next
		{
			get
			{
				if (Items?.Length > 0 && Items?.Length == Weights?.Length)
				{
					var total = 0f;
					var roll = Utility.Random.Next(0, Weights.Sum());
					for (var i = 0; i < Weights.Length; i++)
					{
						total += Weights[i];
						if (roll < total)
							return Items[i];
					}
				}
				return Items[Utility.Random.Next(0, Items.Length)];
			}
		}
	}
}
