using UnityEngine;
[CreateAssetMenu]
public class GenerateMapType : ScriptableObject
{
	public int Width;
	public int Height;
	[ContextMenu("Test!?")]
	public void Test()
	{
		Debug.Log("Test!?");
	}
}
