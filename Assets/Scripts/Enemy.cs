using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayerStats
{
    public BoardTiles Board;
    
    public GameObject destroyed_ship;
    private void Start()
    {
        
    }

    public override void shipDestroyed(uint index)
    {
        base.shipDestroyed(index);
        GameObject g;
        g = Instantiate(destroyed_ship);
        g.SetActive(true);
        g.transform.position = Board.tiles[index].transform.position;
        Board.tiles[index].GetComponent<TileID>().ship = g;
    }
}
