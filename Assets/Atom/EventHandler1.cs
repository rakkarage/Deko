using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	public abstract class EventHandler1<T> : MonoBehaviour
	{
		public string test = "working!?";
		public Event1<T> Event;
		public UnityEvent<T> Response;
		private void OnEnable() => Event.Register(this);
		private void OnDisable() => Event.Unregister(this);
		public void Invoke(T t) => Response.Invoke(t);
	}
}
