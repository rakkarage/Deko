using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/BoundsInt/AtomBoundsInt")]
	public class AtomBoundsInt : AtomReference<BoundsInt, AtomEventBoundsInt, UnityEventBoundsInt> { }
}
