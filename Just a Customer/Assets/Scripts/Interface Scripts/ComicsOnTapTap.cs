using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComicsOnTapTap : MonoBehaviour
{
    public GameObject[] Pics;
    public int Pepe;
    public GameObject[] Targs;
    private int EachBich;

    public void FrameOmon()
    {
        if( Pepe < Pics.Length )
        {
            Pics[Pepe].SetActive( true );
            Pepe++;
        }
    }

    void Start()
    {
        Pics[Pepe].SetActive( true );
        Pepe++;
    }

    void Update()
    {
        foreach( GameObject Mem in Pics )
        {
            if( Pics[ EachBich ].activeSelf == true )
            {
                Pics[ EachBich ].transform.position = Vector3.MoveTowards( Pics[ EachBich ].transform.position, 
                Targs[ EachBich ].transform.position, 0.1f );
            }
            EachBich++;
        }
        EachBich = 0;
    }
}
