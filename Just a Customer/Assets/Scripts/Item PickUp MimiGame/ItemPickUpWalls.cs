using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpWalls : MonoBehaviour
{
    public bool isObjectTouchedWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemToPickUp") isObjectTouchedWall = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ItemToPickUp") isObjectTouchedWall = false;
    }
}
