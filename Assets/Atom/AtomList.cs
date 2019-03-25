using System.Collections.Generic;
using UnityEngine;
namespace ca.HenrySoftware.Atom
{
	public abstract class AtomList<T, E> : ScriptableObject
		where E : AtomEvent<T>
	{
		public List<T> Items = new List<T>();
		public E Added;
		public E Removed;
		public AtomEvent Cleared;
		public void Add(T t)
		{
			if (!Items.Contains(t))
				Items.Add(t);
		}
		public void Remove(T t)
		{
			if (Items.Contains(t))
				Items.Remove(t);
		}
		public T this[int i]
		{
			get { return Items[i]; }
			set { Items[i] = value; }
		}
		public int Count => Items.Count;
		public void Clear() => Items.Clear();
		public bool Contains(T t) => Items.Contains(t);
		public void Reverse() => Items.Reverse();
	}
}
