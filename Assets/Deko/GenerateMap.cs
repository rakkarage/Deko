using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class GenerateMap : MonoBehaviour
{
	public GenerateMapType Type;
	private Tilemap[] Layers;
	[ExecuteInEditMode]
	public void Awake()
	{
		Layers = GetComponentsInChildren<Tilemap>();
	}
	[ContextMenu("Generate")]
	public void Generate()
	{
		Clear();
	}
	[ContextMenu("Clear")]
	public void Clear()
	{
		// Layers = GetComponentsInChildren<Tilemap>();
		foreach (var i in Layers)
		{
			i.ClearAllTiles();
			i.RefreshAllTiles();
			i.size = new Vector3Int(Type.Width, Type.Height, 1);
			i.ResizeBounds();
			i.RefreshAllTiles();
		}
	}
}
