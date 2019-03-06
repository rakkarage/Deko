using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu]
public class Theme : ScriptableObject
{
	public TileBase FloorSimple;
	public TileBase FloorRoom;
	public TileBase Floor;
	public TileBase StairsDown;
	public TileBase StairsUp;
	public TileBase DoorShut;
	public TileBase DoorOpen;
	public TileBase Torch;
	public TileBase WallSimple;
	public TileBase Wall;
}
