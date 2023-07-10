using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Subsequence sucubLeft1;
    public Subsequence sucubLeft2;
    public Subsequence sucubRight1;
    public Subsequence sucubRight2;

    public bool sucubLeftReset1;
    public bool sucubLeftReset2;
    public bool sucubRightReset1;
    public bool sucubRightReset2;

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
    public bool sucubCheck1;
    public bool sucubCheck2;

    void Start()
    {
        leftChangeControlsTimer = Random.Range(leftChangeControlsTimerStartMin, leftChangeControlsTimerStartMax);
        rightChangeControlsTimer = Random.Range(rightChangeControlsTimerStartMin, rightChangeControlsTimerStartMax);
    }

    void Update()
    {
        if(sucubFirstLatterChange == false)
        {
            sucubFirstLatterChange = true;
            sucubLeft1.sequencesRandomFiller(1);
            sucubLeft2.sequencesRandomFiller(1);
            sucubRight1.sequencesRandomFiller(1);
            sucubRight2.sequencesRandomFiller(1);
        }

        if(leftChangeControlsTimer > 0) leftChangeControlsTimer -= Time.deltaTime;
        else
        {
            leftChangeControlsTimer = Random.Range(leftChangeControlsTimerStartMin, leftChangeControlsTimerStartMax);
            sucubLeft1.sequencesRandomFiller(1);
            sucubLeft2.sequencesRandomFiller(1);
        }
        if (rightChangeControlsTimer > 0) rightChangeControlsTimer -= Time.deltaTime;
        else
        {
            rightChangeControlsTimer = Random.Range(rightChangeControlsTimerStartMin, rightChangeControlsTimerStartMax);
            sucubRight2.sequencesRandomFiller(1);
            sucubRight2.sequencesRandomFiller(1);
        }

        if (sucubLeft1.isEverySequencesTrue && !sucubLeftReset1)
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
        }
    }
}
