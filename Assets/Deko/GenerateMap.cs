using UnityEngine;
using UnityEngine.Tilemaps;
public class GenerateMap : MonoBehaviour
{
	public GenerateMapType Type;
	private Tilemap[] Layers;
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
		foreach (var i in Layers)
		{
			i.ClearAllTiles();
			i.ResizeBounds();
			i.size = new Vector3Int(Type.Width, Type.Height, 1);
		}
	}
}
