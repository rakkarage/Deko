using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Deko
{
	[ExecuteInEditMode]
	public class AtomEventHandler : MonoBehaviour
	{
		public AtomEvent Event;
		public UnityEvent Response;
		protected void OnEnable() => Event?.Register(this);
		protected void OnDisable() => Event?.Unregister(this);
		[ContextMenu("Invoke")]
		public void Invoke() => Response?.Invoke();
	}
}
