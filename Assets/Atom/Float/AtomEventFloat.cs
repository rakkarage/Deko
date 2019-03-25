using System;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Float/AtomEventFloat")]
	public class AtomEventFloat : AtomEvent<float> { }
	[Serializable]
	public class UnityEventFloat : UnityEvent<float> { }
}
