﻿using ca.HenrySoftware.Rage;
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
	public List<TileBase> Wall;
	public List<TileBase> Floor;
	public List<TileBase> RoomFloor;
	public List<TileBase> Light;
}