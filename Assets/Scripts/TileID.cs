using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileID : MonoBehaviour
{
    public bool isShipPresent;
    public uint ID;   
    public GameObject ship;


    private void Awake()
    {
        isShipPresent = false;
    }
}
