using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerStats   
{
    public BoardTiles Board;
    private void Start()
    {
        //Board = GameObject.FindGameObjectWithTag("Player_board").GetComponent<BoardTiles>();
    }
    public void setBoard(GameObject board)
    {
        Board = board.GetComponent<BoardTiles>();
    }
    public override void shipDestroyed(uint index)
    {
        if (!Board.tiles[index].GetComponent<TileID>().isShipPresent) return;
        base.shipDestroyed(index);
        Board.tiles[index].GetComponent<TileID>().ship.SetActive(true);
        Board.tiles[index].GetComponent<TileID>().ship.GetComponent<Ship>().destroyed = true;
    }

}
