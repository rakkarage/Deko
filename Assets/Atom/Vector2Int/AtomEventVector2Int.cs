using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Vector2Int/AtomEventVector2Int")]
	public class AtomEventVector2Int : AtomEvent<Vector2Int> { }
	[Serializable]
	public class UnityEventVector2Int : UnityEvent<Vector2Int> { }
}
