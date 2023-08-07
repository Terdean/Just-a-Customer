using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //���������� ���� � ������� ����� �������� ������ ���. � ���� ����� ������� - ��� ��� ������� �� �������.

    public string words; //�����, ��� ����� � ���� ������� (��� �� ��������� �������� ���� �������� �����, ���?)
    public string[] lattersToPress; //��� ����� ����������, ����� ������� ����� ������ ������, ����� �������� (��������: N,O) ������ ��� ������
    public Subsequence sucub; //����������, ������� ����� ���� ��������� ��� ����� �������
    private bool isDialogueCompleted = false; //���� true - �� ������ ������ �� ����������
    private DialogueManager manager;
    public bool isItHasTrigger; //������ ���� � �����, �� �� ������ ����� �������

    //��� ���������� ��������� ����� � ����������� ���������
    public health playersHPLowerBlock;
    public Movement movementBlock;

    void Start()
    {
        manager = GameObject.Find("DialoguesManager").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (!isDialogueCompleted)
        {
            if (sucub.isEverySequencesTrue)
            {
                movementBlock.isMovementBlocked = false;
                //��������� ��������� �����
                manager.dialogueBG.SetActive(false);
                isDialogueCompleted = true;
                manager.isManagerUsed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isDialogueCompleted && isItHasTrigger && !manager.isManagerUsed) dialogueEncounter();
        }
    }

    public void dialogueEncounter() //���� ����� ���������, �����, ���� �������� - ����� ���� �������� ������ ����� ������ �������
    {
        movementBlock.isMovementBlocked = true;
        //���������� ��������� �����
        sucub.sequencecsConstantFiller(lattersToPress);
        manager.textObj.text = words;
        manager.dialogueBG.SetActive(true);
        manager.isManagerUsed = true;
    }
}