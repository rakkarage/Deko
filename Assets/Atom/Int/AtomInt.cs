using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Int/AtomInt")]
	public class AtomInt : AtomReference<int, AtomEventInt, UnityEventInt> { }
}
