using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public abstract class Effect : ScriptableObject
	{
		public Sprite Icon;
		public abstract void OnEquip();
		public abstract void OnUnequip();
	}
}
