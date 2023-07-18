using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingThing : MonoBehaviour
{
    public GameObject SusGet;
    public GameObject TortHere;
     
    void Start()
    {
        transform.position = new Vector3( TortHere.transform.position.x, TortHere.transform.position.y, TortHere.transform.position.z );
    }

   
    void Update()
    {
        transform.position = Vector3.MoveTowards( transform.position, SusGet.transform.position, 0.01f );

        if( transform.position == SusGet.transform.position )
        { 
            transform.position = new Vector3( TortHere.transform.position.x, TortHere.transform.position.y, TortHere.transform.position.z );
        }
    }
}
