using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Float/AtomFloat")]
	public class AtomFloat : AtomReference<float, AtomEventFloat, UnityEventFloat> { }
}
