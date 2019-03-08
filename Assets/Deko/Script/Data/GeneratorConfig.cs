using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class GeneratorConfig : ScriptableObject
	{
		public WeightedTheme Themes;
		public WeightedGenerator Generators;
		[Range(0, 1)]
		public float WallTorchChance = .333f;
	}
}
