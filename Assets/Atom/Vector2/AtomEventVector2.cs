using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Vector2/AtomEventVector2")]
	public class AtomEventVector2 : AtomEvent<Vector2> { }
	[Serializable]
	public class UnityEventVector2 : UnityEvent<Vector2> { }
}
