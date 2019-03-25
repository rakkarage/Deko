using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	public class AtomEvent : ScriptableObject
	{
		private List<AtomEventHandler> Handlers = new List<AtomEventHandler>();
		public void Register(AtomEventHandler handler) => Handlers.Add(handler);
		public void Unregister(AtomEventHandler handler) => Handlers.Remove(handler);
		public void Raise()
		{
			for (var i = Handlers.Count - 1; i > 0; i--)
				Handlers[i].Invoke();
		}
	}
	public abstract class AtomEvent<T> : ScriptableObject
	{
		private List<IAtomEventHandler<T>> Handlers = new List<IAtomEventHandler<T>>();
		public void Register(IAtomEventHandler<T> handler) => Handlers.Add(handler);
		public void Unregister(IAtomEventHandler<T> handler) => Handlers.Remove(handler);
		public void Raise(T t)
		{
			for (var i = Handlers.Count - 1; i >= 0; i--)
				Handlers[i].Invoke(t);
		}
	}
}
