using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOfLifeUpdater : MonoBehaviour
{
    private Game _game;
    private Tilemap tilemap;
    private Tile cellTile;
    IEnumerator coroutine;

    //eigene Lösung:
    //feste spielgröße
    //textur laden und als sprite speichern
    //sprite[,]
    //

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        _game = new Game(tilemap.size.x, tilemap.size.y);
        cellTile = tilemap.GetTile<Tile>(new Vector3Int(-1, 14, 0));
        for (int x = 0; x < tilemap.size.x; x++)
            for (int y = 0; y < tilemap.size.y; y++)
                _game.Set(x, y, tilemap.HasTile(new Vector3Int(x + tilemap.origin.x, y + tilemap.origin.y, 0)));
        coroutine = Tick();
        StartCoroutine(coroutine);
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            _game.Tick();

            for (int x = 0; x < tilemap.size.x; x++)
                for (int y = 0; y < tilemap.size.y; y++)
                {
                    if (_game.Get(x, y)) tilemap.SetTile(new Vector3Int(x + tilemap.origin.x, y + tilemap.origin.y, 0), cellTile);
                    else tilemap.SetTile(new Vector3Int(x + tilemap.origin.x, y + tilemap.origin.y, 0), null);
                }
            //yield return new WaitForSeconds(0.2f);
            yield return null;
        }
    }
}
