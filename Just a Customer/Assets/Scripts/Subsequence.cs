using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsequence : MonoBehaviour
{
    //���� ������ ����� ������������� ��� ������� ���������� �����, ��� ����� �������� ��������������� ������
    //� ����� ����� ������ ����� ������ ������, �������� �� isEverySequencesTrue = true. � ��� ���
    //� ������ ������� ������ ������ ������ ��� �������, ��� ����(isEverySequencesTrue == true), �� ��������� ���.
    //��� �� � ������� ���� ��� ������ ����������: sequencesRandomFiller � sequencecsConstantFiller �� ����� �����
    //��� ���������� �������� ������� ������� ��� ������ �������� �� ���.

    public bool[] sequences; //���� true - ������ ������ ������, ���� false - ������ �� ������
    public string[] latters; //������ ����, ������� ����� ������. ���� � ������ ���� ������ ���� ����������� �������
    private int latterNumber;

    public bool isEverySequencesTrue; //��� ����� ������ ��������� ���������� - ���� ��� ����� ������ � ���������� �������
                                      //�� �� ��������� ��� ���������� � ������ �������� ������ false, ����� ��� ��������.
    public bool playerMissed; //��� ���������� �� ����������� ������ ��������������. �� � �� ������, ��� � isEverySequencesTrue
                              //�� �� ��������� ��� ���������� � ������ �������� ������ false, ����� ��� ��������.

    private KeyCode lastPressedKey;

    private int numForeach = 0; //��� ���� ��������������� ����������, ������ ������� �� ��� � ������ ��� ���� ��� �����
    private int randomFillerForeachNum = 0;
    private int constantFillerForeachNum = 0;
    private int randomLatter;

    void Update()
    {
        whichLatterToPress();

        foreach (bool i in sequences) //�������� ������� ������ ��������� ������ 
        {
            if (sequences[numForeach] == true) numForeach++;

            if (numForeach >= sequences.Length) isEverySequencesTrue = true;
        }
        numForeach = 0;
    }

    public void whichLatterToPress() //��� ��������� �� ������� ������� � ������ �������� ��� �������
    {
        if (latters.Length > latterNumber)
        {
            switch (lastPressedKey)
            {
                case KeyCode.A:
                    if (latters[latterNumber] != "A") playerMissed = true;

                    if (latters[latterNumber] == "A")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash; //��� �����, ����� ���� �� ����������, ��� ������ ������ ������ � �� ��������� �������, ���� ��������� ������ � ������� ���������

                    return;
                case KeyCode.B:
                    if (latters[latterNumber] != "B") playerMissed = true;

                    if (latters[latterNumber] == "B")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.C:
                    if (latters[latterNumber] != "C") playerMissed = true;

                    if (latters[latterNumber] == "C")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.D:
                    if (latters[latterNumber] != "D") playerMissed = true;

                    if (latters[latterNumber] == "D")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.E:
                    if (latters[latterNumber] != "E") playerMissed = true;

                    if (latters[latterNumber] == "E")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.F:
                    if (latters[latterNumber] != "F") playerMissed = true;

                    if (latters[latterNumber] == "F")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.G:
                    if (latters[latterNumber] != "G") playerMissed = true;

                    if (latters[latterNumber] == "G")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.H:
                    if (latters[latterNumber] != "H") playerMissed = true;

                    if (latters[latterNumber] == "H")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.I:
                    if (latters[latterNumber] != "I") playerMissed = true;

                    if (latters[latterNumber] == "I")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.J:
                    if (latters[latterNumber] != "J") playerMissed = true;

                    if (latters[latterNumber] == "J")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.K:
                    if (latters[latterNumber] != "K") playerMissed = true;

                    if (latters[latterNumber] == "K")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.L:
                    if (latters[latterNumber] != "L") playerMissed = true;

                    if (latters[latterNumber] == "L")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.M:
                    if (latters[latterNumber] != "M") playerMissed = true;

                    if (latters[latterNumber] == "M")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.N:
                    if (latters[latterNumber] != "N") playerMissed = true;

                    if (latters[latterNumber] == "N")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.O:
                    if (latters[latterNumber] != "O") playerMissed = true;

                    if (latters[latterNumber] == "O")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.P:
                    if (latters[latterNumber] != "P") playerMissed = true;

                    if (latters[latterNumber] == "P")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.Q:
                    if (latters[latterNumber] != "Q") playerMissed = true;

                    if (latters[latterNumber] == "Q")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.R:
                    if (latters[latterNumber] != "R") playerMissed = true;

                    if (latters[latterNumber] == "R")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.S:
                    if (latters[latterNumber] != "S") playerMissed = true;

                    if (latters[latterNumber] == "S")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.T:
                    if (latters[latterNumber] != "T") playerMissed = true;

                    if (latters[latterNumber] == "T")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.U:
                    if (latters[latterNumber] != "U") playerMissed = true;

                    if (latters[latterNumber] == "U")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.V:
                    if (latters[latterNumber] != "V") playerMissed = true;

                    if (latters[latterNumber] == "V")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.W:
                    if (latters[latterNumber] != "W") playerMissed = true;

                    if (latters[latterNumber] == "W")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.X:
                    if (latters[latterNumber] != "X") playerMissed = true;

                    if (latters[latterNumber] == "X")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.Y:
                    if (latters[latterNumber] != "Y") playerMissed = true;

                    if (latters[latterNumber] == "Y")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
                case KeyCode.Z:
                    if (latters[latterNumber] != "Z") playerMissed = true;

                    if (latters[latterNumber] == "Z")
                    {
                        sequences[latterNumber] = true;
                        latterNumber++;
                    }
                    lastPressedKey = KeyCode.Slash;

                    return;
            }
        }
    }

    public void sequencesRandomFiller(int latterCount) //���� ����� ������ ������� ����� ������ �������, ��� ���������� ���������� ���� ����� ��������
    {
        Array.Resize(ref sequences, latterCount);
        Array.Resize(ref latters, latterCount);

        foreach (string latter in latters)
        {
            sequences[randomFillerForeachNum] = false;

            randomLatter = UnityEngine.Random.Range(0, 25);
            switch (randomLatter)
            {
                case 0:
                    latters[randomLatter] = "A";
                    return;
                case 1:
                    latters[randomLatter] = "B";
                    return;
                case 2:
                    latters[randomLatter] = "C";
                    return;
                case 3:
                    latters[randomLatter] = "D";
                    return;
                case 4:
                    latters[randomLatter] = "E";
                    return;
                case 5:
                    latters[randomLatter] = "F";
                    return;
                case 6:
                    latters[randomLatter] = "G";
                    return;
                case 7:
                    latters[randomLatter] = "H";
                    return;
                case 8:
                    latters[randomLatter] = "I";
                    return;
                case 9:
                    latters[randomLatter] = "J";
                    return;
                case 10:
                    latters[randomLatter] = "K";
                    return;
                case 11:
                    latters[randomLatter] = "L";
                    return;
                case 12:
                    latters[randomLatter] = "M";
                    return;
                case 13:
                    latters[randomLatter] = "N";
                    return;
                case 14:
                    latters[randomLatter] = "O";
                    return;
                case 15:
                    latters[randomLatter] = "P";
                    return;
                case 16:
                    latters[randomLatter] = "Q";
                    return;
                case 17:
                    latters[randomLatter] = "R";
                    return;
                case 18:
                    latters[randomLatter] = "S";
                    return;
                case 19:
                    latters[randomLatter] = "T";
                    return;
                case 20:
                    latters[randomLatter] = "U";
                    return;
                case 21:
                    latters[randomLatter] = "V";
                    return;
                case 22:
                    latters[randomLatter] = "W";
                    return;
                case 23:
                    latters[randomLatter] = "X";
                    return;
                case 24:
                    latters[randomLatter] = "Y";
                    return;
                case 25:
                    latters[randomLatter] = "Z";
                    return;
            }

            randomFillerForeachNum++;
        }
        randomFillerForeachNum = 0;
    }

    public void sequencecsConstantFiller(string[] customArray) //��� ������� ���������� ����� ������ �������, ���������� ������ ��������� ��������� ������ �� ������ �������
    {
        Array.Resize(ref sequences, customArray.Length);
        Array.Resize(ref latters, customArray.Length);

        foreach (string latter in customArray)
        {
            sequences[constantFillerForeachNum] = false;

            latters[constantFillerForeachNum] = customArray[constantFillerForeachNum];
            constantFillerForeachNum++;
        }
        constantFillerForeachNum = 0;
    }

    public void OnGUI() //����� � ������� ������������ ��������� ������� �������
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }
}
