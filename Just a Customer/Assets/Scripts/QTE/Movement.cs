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
}
