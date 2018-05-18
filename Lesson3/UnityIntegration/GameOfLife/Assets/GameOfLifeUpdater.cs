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
		rememberGliderGun = new Game(map.size.x, map.size.y/2);
		for (var x = 0; x < map.size.x; x++)
		for (var y = 0; y < map.size.y; y++)
		{
			bool isSet = map.HasTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0));
			game.Set(x, y, isSet);
			if (y >= rememberGliderGun.Height)
				rememberGliderGun.Set(x, y-rememberGliderGun.Height, isSet);
		}
	}

	private Game game;
	private Game rememberGliderGun;
	private Tilemap map;
	private Tile cellTile;
	
	void Update ()
	{
		if (Input.anyKey)
			for (var x = 0; x < rememberGliderGun.Width; x++)
			for (var y = 0; y < rememberGliderGun.Height; y++)
				game.Set(x, y + rememberGliderGun.Height, rememberGliderGun.IsAlive(x, y));
		if (!Have100MsPassed())
			return;
		game.Tick();
		for (var x = 0; x < map.size.x; x++)
		for (var y = 0; y < map.size.y; y++)
			map.SetTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0),
				game.IsAlive(x, y) ? cellTile : null);
	}

	private bool Have100MsPassed()
	{
		timePassed += Time.deltaTime;
		if (timePassed < 0.1f)
			return false;
		timePassed -= 0.1f;
		return true;
	}

	private float timePassed;
}
