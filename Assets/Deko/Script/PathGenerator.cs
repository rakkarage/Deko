using UnityEngine;
[CreateAssetMenu]
public class PathGenerator : ScriptableObject
{
	public int Width;
	public int Height;
	[ContextMenu("Generate")]
	public void Generate()
	{
		Debug.Log("Test!?");
	}
}
