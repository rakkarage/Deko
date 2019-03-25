using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Bool/AtomEventBool")]
	public class AtomEventBool : AtomEvent<bool> { }
	[Serializable]
	public class UnityEventBool : UnityEvent<bool> { }
}
