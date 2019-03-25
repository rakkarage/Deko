using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Vector3/AtomVector3")]
	public class AtomVector3 : AtomReference<Vector3, AtomEventVector3, UnityEventVector3> { }
}
