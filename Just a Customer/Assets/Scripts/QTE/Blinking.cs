using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public float level; //����� � ���������� ����� ������ ��� ������� ���������� ������, ����� ����� ��� ����� ������ ��� ���� �-�
    //public float blinkLevelDecreaser; //�� ��� �������� ��� � �����-�� ����� ����� ����������� ������� ��������
    //public float blinkLevelIncreser; //�� ������� ������������� ����� ��������, ���� ������ �� ������ �������
    private float againTimer;
    public float againTimerStart; //����� ��� � ������� ����� ���������� ���������� � �������
    private float timeForAction;
    public float startOfTimeForAction; //����� �� ������� ����� ������ ������ ����������� �������
    public GameObject keyObj;
    private bool onlyOneUseOfSucub = false;

    public Subsequence sucub; //���� ���� �������� ��� ������ �� �������� Subsequence, ������� ����� �������� �� ������ ��� ������� ������
    public Text textSign; //�����, ��� ����� ���������� � ���������� ������ ��� ������� �������
    private float sucubTimer;
    public float sucubTimerStart; //����� ��� � ������� ����� �������� ����������
    private bool sucubFirstLatterChange;
    [HideInInspector]
    public ImportantKeysManager importantKeysManager;

    private DepthOfField blur;
    [SerializeField]
    private PostProcessVolume volume; //�������������� ���� ������ � �� ��������
    private float valueMax = 50;
    public float valueCurrent = 50;
    public health PlayerHealth;
    private bool blurRiseNeed; //��� ����� ���� �� ����� ��������� � ���-�� ������� � ������ � ������.
                               //���� false - valueCurrent ��� � 50, ���� true - valueCurrent ��� � valueMax

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out blur);
        againTimer = againTimerStart;
        timeForAction = startOfTimeForAction;
    }

    void Update()
    {
        if (!sucubFirstLatterChange) //�������� ��������� � ������ ����
        {
            sucub.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) sucubFirstLatterChange = true;
        }

        if (againTimer > 0) againTimer -= Time.deltaTime;
        else
        {
            keyObj.SetActive(true);
            if (!onlyOneUseOfSucub)
            {
                sucubRavager();
                onlyOneUseOfSucub = true;
            }

            if (timeForAction > 0) timeForAction -= Time.deltaTime;
            else //���� �� �����
            {
                sucub.sequencesRandomFiller(1);
                importantKeysManager.CheckForSameLatters();
                if (importantKeysManager.isSameLatterFound == false)
                {
                    if (level > -3) level--;

                    keyObj.SetActive(false);
                    againTimer = againTimerStart;
                    timeForAction = startOfTimeForAction;
                    onlyOneUseOfSucub = false;
                }
            }

            if (sucub.isEverySequencesTrue) //���� �����
            {
                sucub.sequencesRandomFiller(1);
                importantKeysManager.CheckForSameLatters();
                if (importantKeysManager.isSameLatterFound == false)
                {
                    if (level < 3) level++;

                    keyObj.SetActive(false);
                    againTimer = againTimerStart;
                    timeForAction = startOfTimeForAction;
                    onlyOneUseOfSucub = false;

                    sucubRavager();
                }
            }
        }

        //if (!sucubFirstLatterChange) //�������� ��������� � ������ ����
        //{
        //    sucub.sequencesRandomFiller(1);

        //    importantKeysManager.CheckForSameLatters();
        //    if (importantKeysManager.isSameLatterFound == false) sucubFirstLatterChange = true;
        //}
        //if (sucubTimer > 0) sucubTimer -= Time.deltaTime;
        //else
        //{
        //    sucub.sequencesRandomFiller(1);
        //    importantKeysManager.CheckForSameLatters();
        //    if (importantKeysManager.isSameLatterFound == false) sucubTimer = sucubTimerStart;
        //}

        //if (blinkTimer > 0 && blinkLevel >= -100) blinkTimer -= Time.deltaTime;
        //else if (blinkTimer <= 0 && blinkLevel >= -100)
        //{
        //    blinkLevel -= blinkLevelDecreaser;
        //    blinkTimer = blinkTimerStart;
        //}

        //if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 30;
        //if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 30;
        blurRising();


        if (level == 0)
        {
            valueMax = 50;
            blur.focalLength.value = valueCurrent;
        }
        if (level <= -1)
        {
            valueMax = 100;
            if (level == -2)
            {
                valueMax = 200;
                PlayerHealth.hp_minus(Time.deltaTime);
            }
            if (level == -3)
            {
                valueMax = 300;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
            }
            blur.focalLength.value = valueCurrent;
        }
        if (level >= 1)
        {
            valueMax = 100;
            if (level == 2)
            {
                valueMax = 200;
                PlayerHealth.hp_minus(Time.deltaTime);
            }
            if (level == 3)
            {
                valueMax = 300;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
            }
            blur.focalLength.value = valueCurrent;
        }

        //if (sucub.isEverySequencesTrue)
        //{
        //    blinkLevel += blinkLevelIncreser;

        //    sucub.isEverySequencesTrue = false;
        //    foreach (bool i in sucub.sequences)
        //    {
        //        sucub.sequences[_foreachNum] = false;
        //        _foreachNum++;
        //    }
        //    _foreachNum = 0;
        //    sucub.latterNumber = 0;
        //}

        textSign.text = sucub.latters[0] + " - ��������";
    }

    private void sucubRavager()
    {
        foreach (bool i in sucub.sequences)
        {
            sucub.sequences[_foreachNum] = false;
            _foreachNum++;
        }
        _foreachNum = 0;
        sucub.isEverySequencesTrue = false;
        sucub.latterNumber = 0;
    }

    private void blurRising() //��� ����� ���� �� ����� ��������� � ���-�� ������� � ������ � ������.
    {
        if(valueMax > 50 && blurRiseNeed)
        {
            if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 45;
            if (valueCurrent >= valueMax) blurRiseNeed = false;
        }
        if(!blurRiseNeed)
        {
            if (valueCurrent > 50) valueCurrent -= Time.deltaTime * 45;
            else blurRiseNeed = true;
        }    
    }
}