using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Bounds/AtomBounds")]
	public class AtomBounds : AtomReference<Bounds, AtomEventBounds, UnityEventBounds> { }
}
