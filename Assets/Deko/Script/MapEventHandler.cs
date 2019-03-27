using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Map))]
	public class MapEventHandler : AtomEventHandler
	{
		public CharacterData Character;
		private Map _map;
		private void Awake()
		{
			_map = GetComponent<Map>();
		}
		public void HandleStartEvent()
		{
			_map.Light(Character.Position);
		}
	}
}
