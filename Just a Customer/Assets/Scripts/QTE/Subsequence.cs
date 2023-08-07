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
    public string[] latters; //������ ����, ������� ����� ������. ���� � ������ ���� ������ ���� ����������� �������. ����� ������ ������!

    //���� ����������, ������� ����� ��� �������� �����. �� ������� � �������� ����� ������ �������� �� ���������� �� �������������, ����� ������ �����:
    [HideInInspector]
    public int latterNumber; //����� ����� ������ ������ ��� �������. ��� ���������� ����� �������� ����� ������ ������� �� ���������� ���� ��������
    public bool isEverySequencesTrue; //��� ����� ������ ��������� ���������� - ���� ��� ����� ������ � ���������� ������� �� ������ true
                                      //�� �� ��������� ��� ���������� � ������ �������� ������ false, ����� ��� ��������.
    public bool playerMissed; //��� ���������� �� ����������� ������ ��������������. �� � �� ������, ��� � isEverySequencesTrue
                              //�� �� ��������� ��� ���������� � ������ �������� ������ false, ����� ��� ��������.

    private KeyCode lastPressedKey;

    //��� ���� ��������������� ����������, ������ ������� �� ��� � ������ ��� ���� ��� �����
    private int _numForeach = 0;
    private int _randomFillerForeachNum = 0;
    private int _constantFillerForeachNum = 0;
    private int _randomLatter;

    void Update()
    {
        whichLatterToPress();

        foreach (bool i in sequences) //�������� ������� ������ ��������� ������ 
        {
            if (sequences[_numForeach] == true) _numForeach++;

            if (_numForeach >= sequences.Length) isEverySequencesTrue = true;
        }
        _numForeach = 0;
    }

    public void whichLatterToPress() //��� ��������� �� ������� ������� � ������ �������� ��� �������
    {
        if (latters.Length > latterNumber)
        {
            switch (lastPressedKey)
            {
                case KeyCode.A:
                    whichLatterToPressCheck("A", 0);
                    return;
                case KeyCode.B:
                    whichLatterToPressCheck("B", 1);
                    return;
                case KeyCode.C:
                    whichLatterToPressCheck("C", 2);
                    return;
                case KeyCode.D:
                    whichLatterToPressCheck("D", 3);
                    return;
                case KeyCode.E:
                    whichLatterToPressCheck("E", 4);
                    return;
                case KeyCode.F:
                    whichLatterToPressCheck("F", 5);
                    return;
                case KeyCode.G:
                    whichLatterToPressCheck("G", 6);
                    return;
                case KeyCode.H:
                    whichLatterToPressCheck("H", 7);
                    return;
                case KeyCode.I:
                    whichLatterToPressCheck("I", 8);
                    return;
                case KeyCode.J:
                    whichLatterToPressCheck("J", 9);
                    return;
                case KeyCode.K:
                    whichLatterToPressCheck("K", 10);
                    return;
                case KeyCode.L:
                    whichLatterToPressCheck("L", 11);
                    return;
                case KeyCode.M:
                    whichLatterToPressCheck("M", 12);
                    return;
                case KeyCode.N:
                    whichLatterToPressCheck("N", 13);
                    return;
                case KeyCode.O:
                    whichLatterToPressCheck("O", 14);
                    return;
                case KeyCode.P:
                    whichLatterToPressCheck("P", 15);
                    return;
                case KeyCode.Q:
                    whichLatterToPressCheck("Q", 16);
                    return;
                case KeyCode.R:
                    whichLatterToPressCheck("R", 17);
                    return;
                case KeyCode.S:
                    whichLatterToPressCheck("S", 18);
                    return;
                case KeyCode.T:
                    whichLatterToPressCheck("T", 19);
                    return;
                case KeyCode.U:
                    whichLatterToPressCheck("U", 20);
                    return;
                case KeyCode.V:
                    whichLatterToPressCheck("V", 21);
                    return;
                case KeyCode.W:
                    whichLatterToPressCheck("W", 22);
                    return;
                case KeyCode.X:
                    whichLatterToPressCheck("X", 23);
                    return;
                case KeyCode.Y:
                    whichLatterToPressCheck("Y", 24);
                    return;
                case KeyCode.Z:
                    whichLatterToPressCheck("Z", 25);
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
            sequences[_randomFillerForeachNum] = false;

            _randomLatter = UnityEngine.Random.Range(0, 25);
            randomLatterFillerSwitch(_randomLatter);

            _randomFillerForeachNum++;
        }
        _randomFillerForeachNum = 0;
    }

    public void sequencecsConstantFiller(string[] customArray) //��� ������� ���������� ����� ������ �������, ���������� ������ ��������� ��������� ������ �� ������ �������
    {
        Array.Resize(ref sequences, customArray.Length);
        Array.Resize(ref latters, customArray.Length);

        foreach (string latter in customArray)
        {
            sequences[_constantFillerForeachNum] = false;

            latters[_constantFillerForeachNum] = customArray[_constantFillerForeachNum];
            _constantFillerForeachNum++;
        }
        _constantFillerForeachNum = 0;
    }

    public void OnGUI() //����� � ������� ������������ ��������� ������� �������
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }

    private void whichLatterToPressCheck(string whichLatter, int posInArray) //��������������� �����, ������� ������ �������� ��������� ������ whichLatterToPress
    {
        if (latters[latterNumber] != whichLatter) playerMissed = true;

        if (latters[latterNumber] == whichLatter)
        {
            sequences[latterNumber] = true;
            latterNumber++;
        }
        lastPressedKey = KeyCode.Slash; //��� �����, ����� ���� �� ����������, ��� ������ ������ ������ � �� ��������� �������, ���� ��������� ������ � ������� ���������
    }

    private void randomLatterFillerSwitch(int latterNumber)
    {
        switch (_randomLatter)
        {
            case 0:
                latters[_randomFillerForeachNum] = "A";
                return;
            case 1:
                latters[_randomFillerForeachNum] = "B";
                return;
            case 2:
                latters[_randomFillerForeachNum] = "C";
                return;
            case 3:
                latters[_randomFillerForeachNum] = "D";
                return;
            case 4:
                latters[_randomFillerForeachNum] = "E";
                return;
            case 5:
                latters[_randomFillerForeachNum] = "F";
                return;
            case 6:
                latters[_randomFillerForeachNum] = "G";
                return;
            case 7:
                latters[_randomFillerForeachNum] = "H";
                return;
            case 8:
                latters[_randomFillerForeachNum] = "I";
                return;
            case 9:
                latters[_randomFillerForeachNum] = "J";
                return;
            case 10:
                latters[_randomFillerForeachNum] = "K";
                return;
            case 11:
                latters[_randomFillerForeachNum] = "L";
                return;
            case 12:
                latters[_randomFillerForeachNum] = "M";
                return;
            case 13:
                latters[_randomFillerForeachNum] = "N";
                return;
            case 14:
                latters[_randomFillerForeachNum] = "O";
                return;
            case 15:
                latters[_randomFillerForeachNum] = "P";
                return;
            case 16:
                latters[_randomFillerForeachNum] = "Q";
                return;
            case 17:
                latters[_randomFillerForeachNum] = "R";
                return;
            case 18:
                latters[_randomFillerForeachNum] = "S";
                return;
            case 19:
                latters[_randomFillerForeachNum] = "T";
                return;
            case 20:
                latters[_randomFillerForeachNum] = "U";
                return;
            case 21:
                latters[_randomFillerForeachNum] = "V";
                return;
            case 22:
                latters[_randomFillerForeachNum] = "W";
                return;
            case 23:
                latters[_randomFillerForeachNum] = "X";
                return;
            case 24:
                latters[_randomFillerForeachNum] = "Y";
                return;
            case 25:
                latters[_randomFillerForeachNum] = "Z";
                return;
        }
    }
}