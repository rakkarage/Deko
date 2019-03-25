using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/BoundsInt/AtomEventBoundsInt")]
	public class AtomEventBoundsInt : AtomEvent<BoundsInt> { }
	[Serializable]
	public class UnityEventBoundsInt : UnityEvent<BoundsInt> { }
}
