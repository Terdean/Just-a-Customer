using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public float level; //����� � ���������� ����� ������ ��� ������� ���������� ������, ����� ����� ��� ����� ������ ��� �������
    //public float breathLevelDecreaser; //�� ��� �������� ��� � �����-�� ����� ����� ����������� ������� ��������
    //public float breathLevelIncreser; //�� ������� ������������� ����� ��������, ���� ������ �� ������ �������
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

    private Vignette vinnipuh;
    [SerializeField]
    private PostProcessVolume volume; //�������������� ���� ������ � �� ��������
    private float valueMax = 0;
    private float valueCurrent = 0;
    public health PlayerHealth;

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out vinnipuh);
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
        if (sucubTimer > 0) sucubTimer -= Time.deltaTime;
        else
        {
            sucub.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) sucubTimer = sucubTimerStart;
        }

        if (againTimer > 0) againTimer -= Time.deltaTime;
        else
        {
            keyObj.SetActive(true);
            if(!onlyOneUseOfSucub)
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

        //if (breathTimer > 0 && breathLevel >= -100) breathTimer -= Time.deltaTime;
        //else if (breathTimer <= 0 && breathLevel >= -100)
        //{
        //    breathLevel -= breathLevelDecreaser;
        //    breathTimer = breathTimerStart;
        //}

        if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 0.04f;
        if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 0.04f;

        if (level == 0)
        {
            valueMax = 0f;
            vinnipuh.intensity.value = valueCurrent;
            PlayerHealth.Malevich.SetInteger("BreathLevel", 0);
        }
        if (level <= -1)
        {
            valueMax = 0.11f;
            if (level > -2) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (level == -2)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (level == -3)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }
        if (level >= 1)
        {
            valueMax = 0.11f;
            if (level < 2) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (level == 2)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (level == 3)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }

        //if (sucub.isEverySequencesTrue)
        //{
        //    breathLevel += breathLevelIncreser;

        //    sucub.isEverySequencesTrue = false;
        //    foreach (bool i in sucub.sequences)
        //    {
        //        sucub.sequences[_foreachNum] = false;
        //        _foreachNum++;
        //    }
        //    _foreachNum = 0;
        //    sucub.latterNumber = 0;
        //}

        textSign.text = sucub.latters[0] + " - ����";
    }

    private void sucubRavager()
    {
        sucub.isEverySequencesTrue = false;
        foreach (bool i in sucub.sequences)
        {
            sucub.sequences[_foreachNum] = false;
            _foreachNum++;
        }
        _foreachNum = 0;
        sucub.latterNumber = 0;
    }
}
