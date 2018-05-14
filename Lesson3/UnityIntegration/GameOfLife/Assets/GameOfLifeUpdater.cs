using System;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOfLifeUpdater : MonoBehaviour
{
	void Start()
	{
		map = GetComponent<Tilemap>();
		game = new Game(map.size.x, map.size.y);
		cellTile = map.GetTile<Tile>(new Vector3Int(5, -1, 0));
		for (var x = 0; x < map.size.x; x++)
		for (var y = 0; y < map.size.y; y++)
			game.Set(x, y, map.HasTile(
				new Vector3Int(x + map.origin.x, y + map.origin.y, 0)));
	}

	private Game game;
	private Tilemap map;
	private Tile cellTile;
	
	void Update ()
	{
		game.Tick();
		map.SetTile(new Vector3Int(0, 0, 0), cellTile);
	}
}
