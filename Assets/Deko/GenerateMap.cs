using ca.HenrySoftware.Rage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class GenerateMap : MonoBehaviour
{
	public List<KeyValuePair<int, string>> Dictionary0;
	public Dictionary<int, string> Dictionary1;
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
		for (var y = 0; y < Type.Height; y++)
			for (var x = 0; x < Type.Width; x++)
				_pathMap.SetRandomFloor(x, y);
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
