using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public abstract class Brain : ScriptableObject
	{
		public Sprite Icon;
		public abstract void OnUpdate();
	}
}
