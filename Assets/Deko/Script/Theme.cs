using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu]
public class Theme : ScriptableObject
{
	public TileBase Floor;
	public TileBase FloorRoom;
	public TileBase StairDown;
	public TileBase StairUp;
	public TileBase DoorShut;
	public TileBase DoorOpen;
	public TileBase DoorBroke;
	public TileBase Torch;
	public TileBase Wall;
	public TileBase WallRoom;
}
