using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Bool/AtomBool")]
	public class AtomBool : AtomReference<bool, AtomEventBool, UnityEventBool> { }
}
