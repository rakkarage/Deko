using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/String/AtomString")]
	public class AtomString : AtomReference<string, AtomEventString, UnityEventString> { }
}
