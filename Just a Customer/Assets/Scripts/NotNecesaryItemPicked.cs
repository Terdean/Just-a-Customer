using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotNecesaryItemPicked : MonoBehaviour
{
    public float Price = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NecesaryItem")
        {
            //бюджет - стоимсть продукта
            gameObject.SetActive(false);
        }
    }
}
