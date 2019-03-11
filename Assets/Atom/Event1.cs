using System;
using System.Collections.Generic;
using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[Serializable]
	public abstract class Event1<T> : ScriptableObject
	{
		private List<EventHandler1<T>> Handlers = new List<EventHandler1<T>>();
		public void Register(EventHandler1<T> handler) => Handlers.Add(handler);
		public void Unregister(EventHandler1<T> handler) => Handlers.Remove(handler);
		public void Raise(T t)
		{
			for (var i = Handlers.Count - 1; i > 0; i--)
				Handlers[i].Invoke(t);
		}
	}
}
