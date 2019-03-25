using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/String/AtomEventString")]
	public class AtomEventString : AtomEvent<string> { }
	[Serializable]
	public class UnityEventString : UnityEvent<string> { }
}
