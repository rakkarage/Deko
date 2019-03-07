using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public abstract class EffectStatChange : Effect
	{
		public Stat Stat;
		public int Amount;
		public override void OnEquip()
		{
		}
		public override void OnUnequip()
		{
		}
	}
}
