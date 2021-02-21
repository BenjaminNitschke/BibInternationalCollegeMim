using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOfLifeUpdater : MonoBehaviour
{
    private Game game;
    private Tilemap map;
    private Tile cellTile;

    private void Start()
    {
        map = GetComponent<Tilemap>();
        game = new Game(map.size.x, map.size.y);
        cellTile = map.GetTile<Tile>(new Vector3Int(-2, 4, 0));

        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                game.Set(x, y, map.HasTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0)));
            }
        }

        StartCoroutine(Tick());
    }


    private void Draw()
    {
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                if (game.IsAlive(x, y))
                {
                    map.SetTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0), cellTile);
                }
                else
                {
                    map.SetTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0), null);
                }
            }
        }
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            game.Tick();
            Draw();
            yield return new WaitForSeconds(.5f);
        }
    }
}