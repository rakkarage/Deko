﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class AtomEvent : ScriptableObject
	{
		private List<AtomEventHandler> Handlers = new List<AtomEventHandler>();
		public void Register(AtomEventHandler handler) => Handlers.Add(handler);
		public void Unregister(AtomEventHandler handler) => Handlers.Remove(handler);
		[ContextMenu("Raise")]
		public void Raise()
		{
			for (var i = Handlers.Count - 1; i >= 0; i--)
				Handlers[i].Invoke();
		}
	}
}
