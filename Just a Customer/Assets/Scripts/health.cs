using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public bool only0;
    public Animator Malevich;
    public float hp_schet;
    public float CamTimer;
    public float CamTimerStart;
    public Animator CamAnimator;
    void Update()
    {
        if (CamTimer > 0) CamTimer -= Time.deltaTime;
        else
        {
            CamAnimator.SetBool("Damage", false);
            CamTimer = CamTimerStart;
        }
        Malevich.SetFloat("Hp", hp_schet);
        if (hp_schet < 0)
        {
            only0 = true;
        }
    }
    public void hp_minus(float dmg)
    {
        CamAnimator.SetBool("Damage", true);
        if (only0==false)
        {
            hp_schet -= dmg;
        }
    }
}
