using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnaSpawn : MonoBehaviour
{
    public GameObject Ena;
    public health HlPnt;
    void Update()
    {
        if (HlPnt.hp_schet <= 0) 
        {
            Ena.SetActive (true); 
        }
    }
}
