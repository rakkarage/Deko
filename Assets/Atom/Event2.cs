using System.Collections.Generic;
using UnityEngine;
namespace ca.HenrySoftware.Atom
{
	public abstract class Event2<T1, T2> : ScriptableObject
	{
		private List<EventHandler2<T1, T2>> Handlers = new List<EventHandler2<T1, T2>>();
		public void Register(EventHandler2<T1, T2> handler) => Handlers.Add(handler);
		public void Unregister(EventHandler2<T1, T2> handler) => Handlers.Remove(handler);
		public void Raise(T1 t1, T2 t2)
		{
			for (var i = Handlers.Count - 1; i > 0; i--)
				Handlers[i].Invoke(t1, t2);
		}
	}
}
