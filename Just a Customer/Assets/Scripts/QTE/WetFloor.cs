using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{
    public Subsequence[] sucubs;
    public float restartTimer = 0;
    public float restartTimerStart;

    private int _foreachNum;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (var sucub in sucubs)
            {
                sucubs[_foreachNum].sequencesRandomFiller(1);
                _foreachNum++;
            }
            _foreachNum = 0;
            restartTimer = restartTimerStart;
        }

        ////if (restartTimer < 1)
        ////{
        ////    if (collision.tag == "Player")
        ////    {
        ////        foreach (var sucub in sucubs)
        ////        {
        ////            sucubs[_foreachNum].sequencesRandomFiller(1);
        ////            _foreachNum++;
        ////        }
        ////        _foreachNum = 0;
        ////        restartTimer = restartTimerStart;
        ////    }
        ////}
    }

    private void Update()
    {
        if (restartTimer > 0) restartTimer -= Time.deltaTime;
    }
}
