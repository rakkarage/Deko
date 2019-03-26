using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[CreateAssetMenu]
	public class PathData : ScriptableObject
	{
		public List<Vector3Int> Steps = new List<Vector3Int>();
		public int Count => Steps.Count;
		public bool Contains(Vector3Int p) => Steps.Contains(p);
		public void Add(Vector3Int p) => Steps.Add(p);
		public void Reverse() => Steps.Reverse();
		public void Clear() => Steps.Clear();
		public Vector3Int this[int key]
		{
			get => Steps[key];
			set => Steps[key] = value;
		}
	}
}
