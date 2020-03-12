using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Sprite up, down;
    private bool _destroyed;
    public bool destroyed
    {
        set
        {
            if (value)
                GetComponent<SpriteRenderer>().sprite = down;
            else
                GetComponent<SpriteRenderer>().sprite = up;
        }
    }
    public Animation destroy_anim;
}
