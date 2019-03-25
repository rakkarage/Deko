using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Int/AtomEventInt")]
	public class AtomEventInt : AtomEvent<int> { }
	[Serializable]
	public class UnityEventInt : UnityEvent<int> { }
}
