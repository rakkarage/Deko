using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	[CreateAssetMenu(menuName = "Atom/Vector2Int/AtomVector2Int")]
	public class AtomVector2Int : AtomReference<Vector2Int, AtomEventVector2Int, UnityEventVector2Int> { }
}
