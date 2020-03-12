using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public bool your_turn;

    public PlayerStats[] players;

    private static MatchController _instance;
    public static MatchController Instance
    {
        get
        {
            return _instance;
        }
        private set
        {

        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (!your_turn) return;


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Ray2D ray = new Ray2D(mousepos, Vector2.zero);
            RaycastHit2D hit;
            hit=Physics2D.Raycast(mousepos, Vector2.zero) ;
            if(hit)
            {
                if(hit.transform.CompareTag("Tile"))
                {
                    players[0].shipDestroyed(hit.transform.GetComponent<TileID>().ID);
                }
            }
        }
    }
}
