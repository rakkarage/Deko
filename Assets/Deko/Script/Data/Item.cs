using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public class Item : ScriptableObject
	{
		public Sprite Icon;
		public Slot Slot;
		public Effect[] Effects;
		public void OnEquip()
		{
			for (var i = 0; i < Effects.Length; i++)
				Effects[i].OnEquip();
		}
		public void OnUnequip()
		{
			for (var i = 0; i < Effects.Length; i++)
				Effects[i].OnUnequip();
		}
	}
}
