using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Deko
{
	public class EventHandler : MonoBehaviour
	{
		public Event Event;
		public UnityEvent Response;
		private void OnEnable() => Event.Register(this);
		private void OnDisable() => Event.Unregister(this);
		public void Invoke() => Response.Invoke();
	}
}
