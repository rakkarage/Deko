using ca.HenrySoftware.Rage;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class GenerateMap : MonoBehaviour
{
	public GenerateMapType Type;
	private List<Tilemap> _layers = new List<Tilemap>();
	private PathMap _pathMap;
	public void Awake()
	{
		_pathMap = GetComponent<PathMap>();
		_layers.Add(_pathMap.BackMap);
		_layers.Add(_pathMap.WaterBackMap);
		_layers.Add(_pathMap.ItemBackMap);
		_layers.Add(_pathMap.WaterForeMap);
		_layers.Add(_pathMap.ForeMap);
		_layers.Add(_pathMap.ItemForeMap);
		_layers.Add(_pathMap.LightMap);
	}
	[ContextMenu("Generate")]
	public void Generate()
	{
		Clear();
	}
	[ContextMenu("Clear")]
	public void Clear()
	{
		Debug.Log(_layers.Count);
		foreach (var i in _layers)
		{
			i.ClearAllTiles();
			i.size = new Vector3Int(Type.Width, Type.Height, 1);
			i.ResizeBounds();
			i.RefreshAllTiles();
		}
	}
}
