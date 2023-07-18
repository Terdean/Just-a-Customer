using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Subsequence sucubLeft1;
    public Subsequence sucubLeft2;
    public Subsequence sucubRight1;
    public Subsequence sucubRight2;

    private bool sucubLeftReset1;
    private bool sucubLeftReset2;
    private bool sucubRightReset1;
    private bool sucubRightReset2;

    private float leftChangeControlsTimer;
    public float leftChangeControlsTimerStartMin;
    public float leftChangeControlsTimerStartMax;

    private float rightChangeControlsTimer;
    public float rightChangeControlsTimerStartMin;
    public float rightChangeControlsTimerStartMax;

    public GameObject LeftSidePoint;
    public GameObject RightSidePoint;

    private bool sucubFirstLatterChange;
    private int sucubsForeachNum;
    //public bool sucubSameLattersFound;
    //private bool playerActuallyNotMissed;

    [HideInInspector]
    public ImportantKeysManager importantKeysManager;

    void Start()
    {
        leftChangeControlsTimer = Random.Range(leftChangeControlsTimerStartMin, leftChangeControlsTimerStartMax);
        rightChangeControlsTimer = Random.Range(rightChangeControlsTimerStartMin, rightChangeControlsTimerStartMax);
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
    }

    void Update()
    {
        if(!sucubFirstLatterChange) //Рандомно заполнить в начале игры
        {
            sucubLeft1.sequencesRandomFiller(1);
            sucubLeft2.sequencesRandomFiller(1);
            sucubRight1.sequencesRandomFiller(1);
            sucubRight2.sequencesRandomFiller(1);

            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) sucubFirstLatterChange = true;
        }

        if(leftChangeControlsTimer > 0) leftChangeControlsTimer -= Time.deltaTime; //Рандомное заполнение раз в рандомное время
        else
        {
            sucubLeft1.sequencesRandomFiller(1);
            sucubLeft2.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) leftChangeControlsTimer = Random.Range(leftChangeControlsTimerStartMin, leftChangeControlsTimerStartMax);
        }
        if (rightChangeControlsTimer > 0) rightChangeControlsTimer -= Time.deltaTime;
        else
        {
            sucubRight1.sequencesRandomFiller(1);
            sucubRight2.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) rightChangeControlsTimer = Random.Range(rightChangeControlsTimerStartMin, rightChangeControlsTimerStartMax);
        }

        if (sucubLeft1.isEverySequencesTrue && !sucubLeftReset1) //Проверка нажатий по клавишам
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftSidePoint.transform.position, 0.5f);
            sucubLeft1.isEverySequencesTrue = false;
            sucubLeft2.isEverySequencesTrue = false;
            foreach (bool i in sucubLeft1.sequences)
            {
                sucubLeft1.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubLeftReset1 = true;
            sucubLeftReset2 = false;
            sucubLeft1.latterNumber = 0;

            foreach (bool i in sucubLeft2.sequences) //Чтобы нельзя было нажать кнопку как-бы заранее. Ведь до этих строчек - если нажать кнопку, даже пока на неё ходить нельзя, то её isEverySequencesTrue станет true
            {
                sucubLeft2.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubLeft2.isEverySequencesTrue = false;
            sucubLeft2.latterNumber = 0;
        }
        if (sucubLeft2.isEverySequencesTrue && !sucubLeftReset2)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftSidePoint.transform.position, 0.5f);
            sucubLeft1.isEverySequencesTrue = false;
            sucubLeft2.isEverySequencesTrue = false;
            foreach (bool i in sucubLeft2.sequences)
            {
                sucubLeft2.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubLeftReset1 = false;
            sucubLeftReset2 = true;
            sucubLeft2.latterNumber = 0;

            foreach (bool i in sucubLeft1.sequences)
            {
                sucubLeft1.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubLeft1.isEverySequencesTrue = false;
            sucubLeft1.latterNumber = 0;
        }
        if (sucubRight1.isEverySequencesTrue && !sucubRightReset1)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightSidePoint.transform.position, 0.5f);
            sucubRight1.isEverySequencesTrue = false;
            sucubRight2.isEverySequencesTrue = false;
            foreach (bool i in sucubRight1.sequences)
            {
                sucubRight1.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubRightReset1 = true;
            sucubRightReset2 = false;
            sucubRight1.latterNumber = 0;

            foreach (bool i in sucubRight2.sequences)
            {
                sucubRight2.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubRight2.isEverySequencesTrue = false;
            sucubRight2.latterNumber = 0;
        }
        if (sucubRight2.isEverySequencesTrue && !sucubRightReset2)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightSidePoint.transform.position, 0.5f);
            sucubRight1.isEverySequencesTrue = false;
            sucubRight2.isEverySequencesTrue = false;
            foreach (bool i in sucubRight2.sequences)
            {
                sucubRight2.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubRightReset1 = false;
            sucubRightReset2 = true;
            sucubRight2.latterNumber = 0;

            foreach (bool i in sucubRight1.sequences)
            {
                sucubRight1.sequences[sucubsForeachNum] = false;
                sucubsForeachNum++;
            }
            sucubsForeachNum = 0;
            sucubRight1.isEverySequencesTrue = false;
            sucubRight1.latterNumber = 0;
        }

        importantKeysManager.MissingCheck();
    }

    //private void CheckForSameLatters() //Проверка есть ли у скриптов одинаковые кнопки
    //{
    //    if (sucubLeft1.isFilledSameLatter || sucubLeft2.isFilledSameLatter ||
    //        sucubRight1.isFilledSameLatter || sucubRight2.isFilledSameLatter)
    //        sucubSameLattersFound = true;
    //    else sucubSameLattersFound = false;

    //    sucubLeft1.isFilledSameLatter = false;
    //    sucubLeft2.isFilledSameLatter = false;
    //    sucubRight1.isFilledSameLatter = false;
    //    sucubRight2.isFilledSameLatter = false;
    //}

    //private void CheckForSameLattersForMissing() //Метод нужен, чтобы игра не защитывала промохи, ведь даже при правильном нажатии на кнопку - у остольных это засчитает, как неверное нажатие. Так вот это фиксится тут
    //{
    //    switch (lastPressedKey)
    //    {
    //        case KeyCode.A:
    //            if (sucubLeft1.latters[0] == "A") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "A") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "A") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "A") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.B:
    //            if (sucubLeft1.latters[0] == "B") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "B") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "B") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "B") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.C:
    //            if (sucubLeft1.latters[0] == "C") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "C") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "C") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "C") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.D:
    //            if (sucubLeft1.latters[0] == "D") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "D") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "D") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "D") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.E:
    //            if (sucubLeft1.latters[0] == "E") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "E") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "E") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "E") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.F:
    //            if (sucubLeft1.latters[0] == "F") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "F") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "F") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "F") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.G:
    //            if (sucubLeft1.latters[0] == "G") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "G") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "G") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "G") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.H:
    //            if (sucubLeft1.latters[0] == "H") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "H") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "H") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "H") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.I:
    //            if (sucubLeft1.latters[0] == "I") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "I") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "I") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "I") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.J:
    //            if (sucubLeft1.latters[0] == "J") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "J") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "J") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "J") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.K:
    //            if (sucubLeft1.latters[0] == "K") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "K") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "K") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "K") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.L:
    //            if (sucubLeft1.latters[0] == "L") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "L") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "L") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "L") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.M:
    //            if (sucubLeft1.latters[0] == "M") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "M") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "M") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "M") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.N:
    //            if (sucubLeft1.latters[0] == "N") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "N") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "N") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "N") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.O:
    //            if (sucubLeft1.latters[0] == "O") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "O") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "O") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "O") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.P:
    //            if (sucubLeft1.latters[0] == "P") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "P") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "P") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "P") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.Q:
    //            if (sucubLeft1.latters[0] == "Q") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "Q") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "Q") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "Q") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.R:
    //            if (sucubLeft1.latters[0] == "R") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "R") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "R") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "R") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.S:
    //            if (sucubLeft1.latters[0] == "S") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "S") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "S") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "S") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.T:
    //            if (sucubLeft1.latters[0] == "T") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "T") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "T") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "T") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.U:
    //            if (sucubLeft1.latters[0] == "U") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "U") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "U") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "U") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.V:
    //            if (sucubLeft1.latters[0] == "V") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "V") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "V") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "V") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.W:
    //            if (sucubLeft1.latters[0] == "W") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "W") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "W") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "W") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.X:
    //            if (sucubLeft1.latters[0] == "X") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "X") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "X") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "X") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.Y:
    //            if (sucubLeft1.latters[0] == "Y") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "Y") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "Y") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "Y") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //        case KeyCode.Z:
    //            if (sucubLeft1.latters[0] == "Z") playerActuallyNotMissed = true;
    //            if (sucubLeft2.latters[0] == "Z") playerActuallyNotMissed = true;
    //            if (sucubRight1.latters[0] == "Z") playerActuallyNotMissed = true;
    //            if (sucubRight2.latters[0] == "Z") playerActuallyNotMissed = true;

    //            if (playerActuallyNotMissed)
    //            {
    //                playerActuallyNotMissed = false;
    //                sucubLeft1.playerMissed = false;
    //                sucubLeft2.playerMissed = false;
    //                sucubRight1.playerMissed = false;
    //                sucubRight2.playerMissed = false;
    //            }
    //            return;
    //    }
    //}
}
