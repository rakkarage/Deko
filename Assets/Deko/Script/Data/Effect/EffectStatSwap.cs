using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public abstract class EffectSwapChange : Effect
	{
		public Stat StatFrom;
		public Stat StatTo;
		public int Amount;
		public override void OnEquip()
		{
		}
		public override void OnUnequip()
		{
		}
	}
}
