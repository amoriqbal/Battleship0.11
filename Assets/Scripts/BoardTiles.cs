using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTiles : MonoBehaviour
{
    public GameObject initialSprite;
    public GameObject[] tiles;
    public uint num_rows,num_columns;
    private Vector2 diff;
    public Vector2 offset;
    public void BuildBoard()
    {
        Vector2 pos;
        GameObject g;


        //initialSprite.SetActive(true);
        uint k = 0;
        for(long i=-(num_columns/2);i<(num_columns+1)/2;i++)
        {
            for(long j=-(num_rows/2);j<(num_rows+1)/2;j++)
            {
                pos = offset + new Vector2(diff.x * i, diff.y * j);
                g=GameObject.Instantiate(initialSprite,transform);
                g.transform.position = new Vector3(pos.x + transform.position.x, pos.y + transform.position.y, 0);
                g.SetActive(true);
                g.GetComponent<TileID>().ID = k;
                tiles[k] = g;
                k++;
            }
        }
    }

    private void Start()
    {
        //initialSprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        initialSprite.transform.localScale = new Vector3(initialSprite.transform.localScale.x / num_columns, initialSprite.transform.localScale.y / num_rows);
        diff.x = transform.localScale.x / num_columns;
        diff.y = transform.localScale.y / num_rows;
        tiles = new GameObject[num_columns * num_rows];
        BuildBoard();
    }
}
