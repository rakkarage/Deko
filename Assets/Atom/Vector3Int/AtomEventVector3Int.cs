using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Vector3Int/AtomEventVector3Int")]
	public class AtomEventVector3Int : AtomEvent<Vector3Int> { }
	[Serializable]
	public class UnityEventVector3Int : UnityEvent<Vector3Int> { }
}
