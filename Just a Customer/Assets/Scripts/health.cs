using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public bool only0;
    public Animator Malevich;
    public float hp_schet;
    void Update()
    {
        Malevich.SetFloat("Hp", hp_schet);
        if (hp_schet<0)
        {
            only0 = true;
        }
    }

    public void hp_minus(float dmg)
    {
        if (only0==false)
        {
            hp_schet -= dmg;
        }
    }
}
