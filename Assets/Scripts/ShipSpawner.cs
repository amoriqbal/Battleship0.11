using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject _ship;
    //public List<GameObject> ship_instances;
    public bool spawning;
    public uint shipCount;
    public void toggleSpawn()
    {
        spawning = !spawning;
    }

    private void Start()
    {
        spawning = false;
        shipCount = 0;
    }
    void Update()
    {
        if (!spawning) return;
        Vector3 mousepos;
        RaycastHit2D[] hit = new RaycastHit2D[10];
        Ray2D ray;
        ContactFilter2D cf = new ContactFilter2D();
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //GameObject go= GameObject.CreatePrimitive(PrimitiveType.Cube);
            //go.transform.position=new Vector3(mousepos.x, mousepos.y, 0);
            ray = new Ray2D(mousepos, Vector2.zero);
            Physics2D.Raycast(ray.origin, ray.direction, cf, hit, 100.0f);
            if (hit[0])
            {
                spawnShip(hit[0]);
                //Debug.Log("lol:" + hit[0].collider.tag);
                //Debug.Log(hit[0].collider.gameObject.name + hit[0].collider.gameObject.GetComponent<ID_number>().ID+" has been hit");
            }
        }
    }

    public void spawnShip(RaycastHit2D hit)
    {
        TileID tid = hit.collider.gameObject.GetComponent<TileID>();
        if (!tid.isShipPresent)
        { 
            tid.isShipPresent = true;
            tid.ship = Instantiate(_ship, hit.transform);
            tid.ship.SetActive(true);
            tid.ship.transform.position = hit.transform.position;
            shipCount++;
        }

        /*uint index = hit.collider.gameObject.GetComponent<TileID>().ID;
        Vector3 pos = hit.collider.transform.position;
        ship_instances.Add(Instantiate(_ship, transform));
        ship_instances[ship_instances.Count - 1].GetComponent<TileID>().ID = index;
        ship_instances[ship_instances.Count - 1].SetActive(true);
        ship_instances[ship_instances.Count - 1].transform.position = pos;*/
    }
}
