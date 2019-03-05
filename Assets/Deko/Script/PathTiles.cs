using ca.HenrySoftware.Rage;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu]
public class PathTiles : ScriptableObject
{
	public TileBase DoorOpen;
	public TileBase DoorShut;
	public TileBase StairsDown;
	public TileBase StairsUp;
	public TileBase Torch;
	public TileBase Wall;
	public TileBase WallSimple;
	public TileBase Floor;
	public TileBase FloorRoom;
	public TileBase FloorSimple;
	public List<TileBase> Light;
}
