using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public uint ID;
    [SerializeField]
    private uint _shipsAlive;
    public uint shipsAlive
    {
        get
        {
            return _shipsAlive;
        }

        private set { }
    }
    //public BoardTiles board;
    public virtual void shipDestroyed(uint index)
    {
        _shipsAlive--;
    }
}
