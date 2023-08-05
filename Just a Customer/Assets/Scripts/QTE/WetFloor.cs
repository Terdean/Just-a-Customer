using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{
    //Объекты с этим скриптом должны находиться на той же высоте (Y), что и вадим
    //Скрипт для смены управления движения, если игрок наступит на мокрый пол

    public Subsequence[] sucubs;
    private float restartTimer = 0;
    public float restartTimerStart;
    private Transform player;
    private ImportantKeysManager importantKeysManager;

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (restartTimer > 0) restartTimer -= Time.deltaTime;
        else
        {
            if (Vector2.Distance(transform.position, player.position) < 2)
            {
                foreach (var sucub in sucubs)
                {
                    sucubs[_foreachNum].sequencesRandomFiller(1);
                    _foreachNum++;
                }
                _foreachNum = 0;
                if (importantKeysManager.isSameLatterFound == false) restartTimer = restartTimerStart;
            }
        }
    }
}
