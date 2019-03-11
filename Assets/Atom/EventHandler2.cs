using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Deko
{
	public abstract class EventHandler2<T1, T2> : MonoBehaviour
	{
		public Event2<T1, T2> Event;
		public UnityEvent<T1, T2> Response;
		private void OnEnable() => Event.Register(this);
		private void OnDisable() => Event.Unregister(this);
		public void Invoke(T1 t1, T2 t2) => Response.Invoke(t1, t2);
	}
}
