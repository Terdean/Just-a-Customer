using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public float blinkLevel; //����� � ���������� ����� ������ ��� ������� ���������� ������, ����� ����� ��� ����� ������ ��� ���� �-�
    public float blinkLevelDecreaser; //�� ��� �������� ��� � �����-�� ����� ����� ����������� ������� ��������
    public float blinkLevelIncreser; //�� ������� ������������� ����� ��������, ���� ������ �� ������ �������
    private float blinkTimer;
    public float blinkTimerStart; //����� ��� � ������� ����� ����������� ������� ��������

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
    private float valueCurrent = 50;

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out blur);
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

        if (blinkTimer > 0 && blinkLevel >= -100) blinkTimer -= Time.deltaTime;
        else
        {
            blinkLevel -= blinkLevelDecreaser;
            blinkTimer = blinkTimerStart;
        }

        if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 10;
        if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 10;
        
        if (blinkLevel > -20 && blinkLevel < 70)
        {
            valueMax = 50;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -20)
        {
            valueMax = 100;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -50)
        {
            valueMax = 200;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -80)
        {
            valueMax = 300;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 70)
        {
            valueMax = 100;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 80)
        {
            valueMax = 200;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 90)
        {
            valueMax = 300;
            blur.focalLength.value = valueCurrent;
        }

        if (sucub.isEverySequencesTrue)
        {
            blinkLevel += blinkLevelIncreser;

            sucub.isEverySequencesTrue = false;
            foreach (bool i in sucub.sequences)
            {
                sucub.sequences[_foreachNum] = false;
                _foreachNum++;
            }
            _foreachNum = 0;
            sucub.latterNumber = 0;
        }

        textSign.text = sucub.latters[0] + " - ��������";
    }
}