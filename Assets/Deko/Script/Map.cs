using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace ca.HenrySoftware.Deko
{
	[ExecuteInEditMode]
	public class Map : MonoBehaviour
	{
		public WeightedGenerator Generators;
		private Generator _generator;
		private bool _mixRoomFloor;
		private bool _allRoomFloor;
		public WeightedTheme Themes;
		private Theme _theme;
		public WeightedLightTile LightTiles;
		private LightTile _lightTile;
		public Tilemap BackMap;
		public Tilemap WaterBackMap;
		public Tilemap ItemBackMap;
		public Tilemap WaterForeMap;
		public Tilemap ForeMap;
		public Tilemap ItemForeMap;
		public Tilemap LightMap;
		public BoundsInt Bounds => BackMap.cellBounds;
		public int Height => Bounds.size.y;
		public int Width => Bounds.size.x;
		public int TileIndex(Vector3Int p) => TileIndex(p.x, p.y);
		public int TileIndex(Vector2Int p) => TileIndex(p.x, p.y);
		public int TileIndex(int x, int y) => y * Width + x;
		public bool InsideEdge(Vector3Int p) => InsideEdge(p.x, p.y);
		public bool InsideEdge(Vector2Int p) => InsideEdge(p.x, p.y);
		public bool InsideEdge(int x, int y) => InsideMap(x, y, 1);
		public bool InsideMap(Vector3Int p) => InsideMap(p.x, p.y);
		public bool InsideMap(Vector2Int p) => InsideMap(p.x, p.y);
		public bool InsideMap(int x, int y, int edge = 0) =>
			(x >= 0 + edge) && (y >= 0 + edge) && (x < Width - edge) && (y < Height - edge);
		public bool IsFloorSimple(int x, int y) => IsFloorSimple(new Vector3Int(x, y, 0));
		public bool IsFloorSimple(Vector2Int p) => IsFloorSimple(p.Vector3Int());
		public bool IsFloorSimple(Vector3Int p) => BackMap.GetTile(p) == _theme.FloorSimple;
		public void SetFloorSimple(int x, int y) => SetFloorSimple(new Vector3Int(x, y, 0));
		public void SetFloorSimple(Vector2Int p) => SetFloorSimple(p.Vector3Int());
		public void SetFloorSimple(Vector3Int p) => BackMap.SetTile(p, _theme.FloorSimple);
		public bool IsFloorRoom(int x, int y) => IsFloorRoom(new Vector3Int(x, y, 0));
		public bool IsFloorRoom(Vector2Int p) => IsFloorRoom(p.Vector3Int());
		public bool IsFloorRoom(Vector3Int p) => BackMap.GetTile(p) == _theme.FloorRoom;
		public void SetFloorRoom(int x, int y) => SetFloorRoom(new Vector3Int(x, y, 0));
		public void SetFloorRoom(Vector2Int p) => SetFloorRoom(p.Vector3Int());
		public void SetFloorRoom(Vector3Int p) => BackMap.SetTile(p, _theme.FloorRoom);
		public bool IsFloor(int x, int y) => IsFloor(new Vector3Int(x, y, 0));
		public bool IsFloor(Vector2Int p) => IsFloor(p.Vector3Int());
		public bool IsFloor(Vector3Int p)
		{
			var tile = BackMap.GetTile(p);
			return tile == _theme.FloorSimple || tile == _theme.FloorRoom;
		}
		public void SetFloor(int x, int y) => SetFloor(new Vector3Int(x, y, 0));
		public void SetFloor(Vector2Int p) => SetFloor(p.Vector3Int());
		public void SetFloor(Vector3Int p)
		{
			if (_allRoomFloor || (_mixRoomFloor && Utility.Random.NextPercent(_generator.RoomFloorChance)))
				SetFloorRoom(p);
			else
				SetFloorSimple(p);
		}
		public bool IsWall(int x, int y) => IsWall(new Vector3Int(x, y, 0));
		public bool IsWall(Vector2Int p) => IsWall(p.Vector3Int());
		public bool IsWall(Vector3Int p)
		{
			var tile = BackMap.GetTile(p);
			return tile == _theme.WallSimple || tile == _theme.WallRoom || tile == _theme.Torch;
		}
		public void SetWall(int x, int y) => SetWall(new Vector3Int(x, y, 0));
		public void SetWall(Vector2Int p) => SetWall(p.Vector3Int());
		public void SetWall(Vector3Int p)
		{
			if (_generator.RoomWallChance < Utility.Random.NextFloat())
				BackMap.SetTile(p, _theme.WallRoom);
			else
				SetWallSimple(p);
		}
		public void SetWallSimple(int x, int y) => SetWallSimple(new Vector3Int(x, y, 0));
		public void SetWallSimple(Vector2Int p) => SetWallSimple(p.Vector3Int());
		public void SetWallSimple(Vector3Int p) => BackMap.SetTile(p, _theme.WallSimple);
		public bool IsStairs(int x, int y) => IsStairs(new Vector3Int(x, y, 0));
		public bool IsStairs(Vector2Int p) => IsStairs(p.Vector3Int());
		public bool IsStairs(Vector3Int p) => IsStairsUp(p) || IsStairsDown(p);
		public bool IsStairsUp(int x, int y) => IsStairsUp(new Vector3Int(x, y, 0));
		public bool IsStairsUp(Vector2Int p) => IsStairsUp(p.Vector3Int());
		public bool IsStairsUp(Vector3Int p) => ForeMap.GetTile(p) == _theme.StairUp;
		public bool IsStairsDown(int x, int y) => IsStairsDown(new Vector3Int(x, y, 0));
		public bool IsStairsDown(Vector2Int p) => IsStairsDown(p.Vector3Int());
		public bool IsStairsDown(Vector3Int p) => ForeMap.GetTile(p) == _theme.StairDown;
		public bool IsDoor(int x, int y) => IsDoor(new Vector3Int(x, y, 0));
		public bool IsDoor(Vector2Int p) => IsDoor(p.Vector3Int());
		public bool IsDoor(Vector3Int p) => IsDoorOpen(p) || IsDoorShut(p);
		public bool IsDoorOpen(int x, int y) => IsDoorOpen(new Vector3Int(x, y, 0));
		public bool IsDoorOpen(Vector2Int p) => IsDoorOpen(p.Vector3Int());
		public bool IsDoorOpen(Vector3Int p) => ForeMap.GetTile(p) == _theme.DoorOpen;
		public bool IsDoorShut(int x, int y) => IsDoorShut(new Vector3Int(x, y, 0));
		public bool IsDoorShut(Vector2Int p) => IsDoorShut(p.Vector3Int());
		public bool IsDoorShut(Vector3Int p) => ForeMap.GetTile(p) == _theme.DoorShut;
		public void ToggleDoor(Vector3Int p)
		{
			if (IsDoorShut(p))
				ForeMap.SetTile(p, _theme.DoorOpen);
			else if (IsDoorOpen(p))
				ForeMap.SetTile(p, _theme.DoorShut);
		}
		public bool IsBlocked(int x, int y) => IsBlocked(new Vector3Int(x, y, 0));
		public bool IsBlocked(Vector2Int p) => IsBlocked(p.Vector3Int());
		public bool IsBlocked(Vector3Int p)
		{
			return IsWall(p) || !IsFloor(p);
		}
		public Color GetColor(Vector3Int p)
		{
			if (IsDoor(p))
				return Colors.Blue;
			else if (IsStairs(p))
				return Colors.Yellow;
			return IsBlocked(p) ? Colors.Red : Colors.Green;
		}
		const float _bright = 1f;
		const float _dim = .5f;
		const float _unlit = .333f;
		public Color GetMapColor(int x, int y, bool screen = false) => GetMapColor(new Vector3Int(x, y, 0), screen);
		public Color GetMapColor(Vector2Int p, bool screen = false) => GetMapColor(p.Vector3Int(), screen);
		public Color GetMapColor(Vector3Int p, bool screen = false)
		{
			var lit = IsLight(p);
			var explored = IsLightExplored(p);
			var wall = IsWall(p);
			var stairs = IsStairs(p);
			var door = IsDoor(p);
			var floor = IsFloor(p);
			var color = screen ? Color.magenta.SetAlpha(.5f) : Color.clear;
			if (explored || lit)
			{
				if (stairs)
					color = Colors.YellowLight.SetAlpha(_bright);
				else if (door)
					color = Colors.BlueLight.SetAlpha(_bright);
				else if (wall && !screen)
					color = Colors.GreyDark.SetAlpha(_dim);
				else if (floor && !screen)
					color = Colors.Grey.SetAlpha(lit ? _dim : _unlit);
			}
			return color;
		}
		public int LightRadius = 5;
		public int TorchRadius = 5;
		private const int _lightExplored = 7;
		private const int _lightMin = 0;
		private const int _lightMax = 31;
		private const int _lightCount = _lightMax + 1;
		public bool IsLight(int x, int y) => IsLight(new Vector3Int(x, y, 0));
		public bool IsLight(Vector2Int p) => IsLight(p.Vector3Int());
		public bool IsLight(Vector3Int p)
		{
			var tile = LightMap.GetTile(p) as LightTile;
			if (!tile) return false;
			return tile.Level > _lightExplored;
		}
		public bool IsLightExplored(int x, int y) => IsLightExplored(new Vector3Int(x, y, 0));
		public bool IsLightExplored(Vector2Int p) => IsLightExplored(p.Vector3Int());
		public bool IsLightExplored(Vector3Int p)
		{
			var tile = LightMap.GetTile(p) as LightTile;
			if (!tile) return false;
			return tile.Level == _lightExplored;
		}
		public void SetLight(int x, int y, int index, bool test) => SetLight(new Vector3Int(x, y, 0), index, test);
		public void SetLight(Vector2Int p, int index, bool test) => SetLight(p.Vector3Int(), index, test);
		public void SetLight(Vector3Int p, int index, bool test)
		{
			var tile = LightMap.GetTile(p) as LightTile;
			if (tile == null)
				Debug.Log("LightError");
			// TODO: need to setup light? this is called from setup light
			if (!test || (index > tile.Level))
				tile.Level = index;
		}
		public void Dark(int index = _lightMin)
		{
			// _lightTheme
			// foreach (var p in Bounds.allPositionsWithin)
			// LightMap.SetTile(LightTheme)
			// 	SetLight(p, index, false);
		}
		private void Darken()
		{
			foreach (var p in Bounds.allPositionsWithin)
			{
				var tile = LightMap.GetTile(p) as LightTile;
				if (tile != null && tile.Level != _lightMin)
					tile.Level = _lightExplored;
			}
		}
		private static int[,] _fovOctants =
		{
			{1,  0,  0, -1, -1,  0,  0,  1},
			{0,  1, -1,  0,  0, -1,  1,  0},
			{0,  1,  1,  0,  0, -1, -1,  0},
			{1,  0,  0,  1, -1,  0,  0, -1},
		};
		private void EmitLightFromRecursive(int x, int y, int radius, int maxRadius, float start, float end, int xx, int xy, int yx, int yy)
		{
			if (start < end) return;
			float rSquare = maxRadius * maxRadius;
			float r2 = maxRadius + maxRadius;
			float newStart = 0.0f;
			for (int i = radius; i <= maxRadius; i++)
			{
				int dx = -i - 1;
				int dy = -i;
				bool isBlocked = false;
				while (dx <= 0)
				{
					dx += 1;
					float mx = x + dx * xx + dy * xy;
					float my = y + dx * yx + dy * yy;
					float lSlope = (dx - 0.5f) / (dy + 0.5f);
					float rSlope = (dx + 0.5f) / (dy - 0.5f);
					if (start < rSlope) continue;
					else if (end > lSlope) break;
					else
					{
						if (!InsideMap((int)mx, (int)my))
							continue;
						var distanceSquare = (int)((mx - x) * (mx - x) + (my - y) * (my - y));
						if (distanceSquare < rSquare)
						{
							double intensity1 = 1d / (1d + distanceSquare / r2);
							double intensity2 = intensity1 - (1d / (1d + rSquare));
							double intensity = intensity2 / (1d - (1d / (1d + rSquare)));
							var index = (int)(intensity * _lightCount);
							if (index > 0)
								SetLight((int)mx, (int)my, index, true);
						}
						if (isBlocked)
						{
							if (IsBlocked((int)mx, (int)my) || IsDoorShut((int)mx, (int)my))
							{
								newStart = rSlope;
								continue;
							}
							else
							{
								isBlocked = false;
								start = newStart;
							}
						}
						else if ((IsBlocked((int)mx, (int)my) || IsDoorShut((int)mx, (int)my)) && (radius < maxRadius))
						{
							isBlocked = true;
							EmitLightFromRecursive(x, y, i + 1, maxRadius, start, lSlope, xx, xy, yx, yy);
							newStart = rSlope;
						}
					}
				}
				if (isBlocked) break;
			}
		}
		public void EmitLight(int x, int y) => EmitLight(new Vector3Int(x, y, 0));
		public void EmitLight(Vector2Int p) => EmitLight(p.Vector3Int());
		public void EmitLight(Vector3Int p) => EmitLight(p, LightRadius);
		public void EmitLight(int x, int y, int radius) => EmitLight(new Vector3Int(x, y, 0), radius);
		public void EmitLight(Vector2Int p, int radius) => EmitLight(p.Vector3Int(), radius);
		public void EmitLight(Vector3Int p, int radius)
		{
			for (int i = 0; i < 8; i++)
			{
				EmitLightFromRecursive(p.x, p.y, 1, radius, 1f, 0f, _fovOctants[0, i], _fovOctants[1, i], _fovOctants[2, i], _fovOctants[3, i]);
			}
			SetLight(p, _lightMax, true);
		}
		public void Light(Vector3Int p)
		{
			Darken();
			EmitLight(p, LightRadius);
			LightTorches();
		}
		private List<Tilemap> _layers = new List<Tilemap>();
		private void Awake()
		{
			_layers.Add(BackMap);
			_layers.Add(WaterBackMap);
			_layers.Add(ItemBackMap);
			_layers.Add(WaterForeMap);
			_layers.Add(ForeMap);
			_layers.Add(ItemForeMap);
			_layers.Add(LightMap);
			FindTorches();
			LightTorches();
		}

		[ContextMenu("Generate")]
		public void Generate()
		{
			Clear();
			for (var y = 0; y < _generator.Height; y++)
			{
				for (var x = 0; x < _generator.Width; x++)
				{
					SetFloor(x, y);
					if (x == 0 || x == _generator.Width - 1 ||
						y == 0 || y == _generator.Height - 1)
						SetWall(x, y);
				}
			}
			BackMap.RefreshAllTiles();
			ForeMap.RefreshAllTiles();
		}
		[ContextMenu("Clear")]
		public void Clear()
		{
			_generator = Generators.Next;
			_mixRoomFloor = Utility.Random.NextPercent(_generator.MixRoomFloorChance);
			_allRoomFloor = Utility.Random.NextPercent(_generator.AllRoomFloorChance);
			_theme = Themes.Next;
			_lightTile = LightTiles.Next;
			foreach (var i in _layers)
			{
				i.ClearAllTiles();
				i.size = new Vector3Int(_generator.Width, _generator.Height, 1);
				i.ResizeBounds();
				i.RefreshAllTiles();
			}
		}
		private List<Vector3Int> _torches = new List<Vector3Int>();
		public void FindTorches()
		{
			if (_theme == null) return;
			foreach (var p in ForeMap.cellBounds.allPositionsWithin)
				if (ForeMap.GetTile(p) == _theme.Torch)
					_torches.Add(p);
		}
		private int RandomTorchRadius => Utility.Random.Next(TorchRadius) + 1;
		private void LightTorches()
		{
			var repeat = 2;
			while (repeat-- > 0)
			{
				foreach (var p in _torches)
				{
					Vector3Int north, east, south, west;
					north = east = south = west = p;
					north.y += 1;
					east.x += 1;
					south.y -= 1;
					west.x -= 1;
					var emitted = false;
					if (InsideMap(p) && IsWall(p))
					{
						if (InsideMap(north) && IsLight(north) && !IsWall(north) && !IsDoorShut(north))
						{
							emitted = true;
							EmitLight(north, RandomTorchRadius);
						}
						if (InsideMap(east) && IsLight(east) && !IsWall(east) && !IsDoorShut(east))
						{
							emitted = true;
							EmitLight(east, RandomTorchRadius);
						}
						if (InsideMap(south) && IsLight(south) && !IsWall(south) && !IsDoorShut(south))
						{
							emitted = true;
							EmitLight(south, RandomTorchRadius);
						}
						if (InsideMap(west) && IsLight(west) && !IsWall(west) && !IsDoorShut(west))
						{
							emitted = true;
							EmitLight(west, RandomTorchRadius);
						}
						if (!emitted)
						{
							Vector3Int northEast, southEast, southWest, northWest;
							northEast = southEast = southWest = northWest = p;
							northEast.y += 1;
							northEast.x += 1;
							northWest.y += 1;
							northWest.x -= 1;
							southEast.y -= 1;
							southEast.x += 1;
							southWest.y -= 1;
							southWest.x -= 1;
							var blockedNorth = !InsideMap(north) || IsWall(north) || IsDoorShut(north);
							var blockedEast = !InsideMap(east) || IsWall(east) || IsDoorShut(east);
							var blockedSouth = !InsideMap(south) || IsWall(south) || IsDoorShut(south);
							var blockedWest = !InsideMap(west) || IsWall(west) || IsDoorShut(west);
							if (InsideMap(northEast) && IsLight(northEast) && !IsWall(northEast) && !IsDoorShut(northEast) && blockedNorth && blockedEast)
								EmitLight(northEast, RandomTorchRadius);
							if (InsideMap(southEast) && IsLight(southEast) && !IsWall(southEast) && !IsDoorShut(southEast) && blockedSouth && blockedEast)
								EmitLight(southEast, RandomTorchRadius);
							if (InsideMap(southWest) && IsLight(southWest) && !IsWall(southWest) && !IsDoorShut(southWest) && blockedSouth && blockedWest)
								EmitLight(southWest, RandomTorchRadius);
							if (InsideMap(northWest) && IsLight(northWest) && !IsWall(northWest) && !IsDoorShut(northWest) && blockedNorth && blockedWest)
								EmitLight(northWest, RandomTorchRadius);
						}
					}
					else if (IsLight(p))
						EmitLight(p, RandomTorchRadius);
				}
			}
		}
	}
}
