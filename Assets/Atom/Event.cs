using System.Collections.Generic;
using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class Event : ScriptableObject
	{
		private List<EventHandler> Handlers = new List<EventHandler>();
		public void Register(EventHandler handler) => Handlers.Add(handler);
		public void Unregister(EventHandler handler) => Handlers.Remove(handler);
		public void Raise()
		{
			for (var i = Handlers.Count - 1; i > 0; i--)
				Handlers[i].Invoke();
		}
	}
}
