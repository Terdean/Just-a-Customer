using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsequence : MonoBehaviour
{
    //Этот скрипт будет накладываться для каждого отдельного места, где нужно нажимать последовательно кнопки
    //и нужно будет чекать через другой скрипт, является ли isEverySequencesTrue = true. И там уже
    //в другом скрипте должно стоять нужное вам условие, мол Если(isEverySequencesTrue == true), то выполняем код.
    //Так же в скрипте есть два метода интересных: sequencesRandomFiller и sequencecsConstantFiller их можно юзать
    //для заполнения массивов нужными буквами при помощи скриптов из вне.

    //[Header("Settings only for this Sequence")]
    public bool[] sequences; //Если true - значит кнопка нажата, если false - значит не нажата
    public string[] latters; //Список букв, которые нужно нажать. Этот и массив выше должны быть одинакового размера. Буквы строго капсом!
    [HideInInspector]
    public int latterNumber; //Номер буквы нужной сейчас для нажатия. Эту переменную нужно обнулять через другие скрипты по выполнении всех действий

    //[HideInInspector]
    //public int IDOfSequence; //Этот ID для чтобы можно было изменять currentlyUsedKeys только от нужного Subsequence
    //                         //Он даётся в скрипте ImportantKeyManager

    public bool isEverySequencesTrue; //Это самая важная финальная переменная - Если все буквы нажаты в правильном порядке
                                      //Но не забывайте эту переменную в других скриптах делать false, когда код сделался.
    public bool playerMissed; //Эта переменная не обязательно должна использоваться. Но у неё работа, как у isEverySequencesTrue
                              //Но не забывайте эту переменную в других скриптах делать false, когда код сделался.
    //[HideInInspector]
    //public ImportantKeyManager importantKeyManager; //Надо заполнять в ручную всеми Subsequence, что есть на сцене

    ////public int idOfAction;
    //private bool isIdOfActionUsed = false;
    //public CurrentlyUsedKeys[] keysUsedByActions; //Статичный массив вообще всех требуемых для управления букв.
    //                                              //Вообще всех - значит из всех вообще применений скрипта Subsequence в игре.
    //                                              //Благодаря этом массиву была оптимизированна огромная часть игры :О
    //public CurrentlyUsedKeys[] check;

    private KeyCode lastPressedKey;

    //Тут куча вспомогательных переменных, просто тыкните на них и поймёте для чего они нужны
    private int _numForeach = 0;
    private int _randomFillerForeachNum = 0;
    private int _constantFillerForeachNum = 0;
    private int _randomLatter;
    private int _foreachImportantKeyCheckNum1 = 0;
    private int _foreachImportantKeyCheckNum2 = 0;
    private bool _isMissJustified;
    private int _starterForeachNum = 0;

    private int _checkNum1;
    private int _checkNum2;



    //static bool[] currentlyUsedKeys; //Это один из самых важных тут массивов и работает он очень просто - в нём 26 позиций, как в алфавите
    //                                 //и каждая позиция обозначает свою букву в алфавитном порядке. Если позиция = true, то эта
    //                                 //буква используется и другие кнопки не будут обращать внимания, если нажали не на них.
    //[Header("Settings of all Sequences")]
    //public bool[] currentlyUsedKeysCheck;

    //public bool isFilledSameLatter = false;

    //private bool isKeysCheckNeed = true; //Этот bool просто чтобы не проверять 60 раз в секунду весь форыч

    //private int _foreachNum1 = 0;
    //private int _foreachNum2 = 0;
    //private int _otherSucubsForeachNum1 = 0;
    //private int _otherSucubsForeachNum2 = 0;
    //private bool[] _whichKeysNowTrue;
    //private int _whichKeysTrueForeachNum;
    //private bool[] _whichKeysNowTrueInOtherSucubs;
    //private int _whickKeysTrueInOtherForachNum;
    //private int _checkForeachNum;

    private void Start()
    {
        //importantKeyManager = GameObject.Find("ImportantKeyManager").GetComponent<ImportantKeyManager>();
        //Array.Resize(ref currentlyUsedKeys, 26);
        //Array.Resize(ref currentlyUsedKeysCheck, 26);
        //Array.Resize(ref _whichKeysNowTrue, 26);
        //Array.Resize(ref _whichKeysNowTrueInOtherSucubs, 26);
    }

    void Update()
    {
        //if (!isIdOfActionUsed) //Для заполнения общего массива, если Subsequence заполняется вручную
        //{
        //    foreach (var latter in latters)
        //    {
        //        ImportantKeysStaticArraysChange(latters[_starterForeachNum], idOfAction, _starterForeachNum);
        //        _starterForeachNum++;
        //    }
        //    _starterForeachNum = 0;

        //    isKeysCheckNeed = true;
        //    isIdOfActionUsed = true;
        //}

        //ImportantKeysStaticArrayChange();
        whichLatterToPress();

        //foreach (var key in currentlyUsedKeysCheck)
        //{
        //    currentlyUsedKeysCheck[_checkForeachNum] = currentlyUsedKeys[_checkForeachNum];
        //    _checkForeachNum++;
        //}
        //_checkForeachNum = 0;

        foreach (bool i in sequences) //Проверка сколько клавиш правильно нажато 
        {
            if (sequences[_numForeach] == true) _numForeach++;

            if (_numForeach >= sequences.Length) isEverySequencesTrue = true;
        }
        _numForeach = 0;
    }

    public void whichLatterToPress() //Чек совпадает ли нажатая клавиша с нужной клавишей для нажатия
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

    public void sequencesRandomFiller(int latterCount) //Этот метод должен юзаться через другие скрипты, для рандомного заполнения двух наших массивов
    {
        Array.Resize(ref sequences, latterCount);
        Array.Resize(ref latters, latterCount);

        foreach (string latter in latters)
        {
            sequences[_randomFillerForeachNum] = false;

            _randomLatter = UnityEngine.Random.Range(0, 25);
            switch (_randomLatter)
            {
                case 0:
                    latters[_randomFillerForeachNum] = "A";
                    //ImportantKeysStaticArraysChange("A", IDofAction, _randomFillerForeachNum);
                    return;
                case 1:
                    latters[_randomFillerForeachNum] = "B";
                    //ImportantKeysStaticArraysChange("B", IDofAction, _randomFillerForeachNum);
                    return;
                case 2:
                    latters[_randomFillerForeachNum] = "C";
                    //ImportantKeysStaticArraysChange("C", IDofAction, _randomFillerForeachNum);
                    return;
                case 3:
                    latters[_randomFillerForeachNum] = "D";
                    //ImportantKeysStaticArraysChange("D", IDofAction, _randomFillerForeachNum);
                    return;
                case 4:
                    latters[_randomFillerForeachNum] = "E";
                    //ImportantKeysStaticArraysChange("E", IDofAction, _randomFillerForeachNum);
                    return;
                case 5:
                    latters[_randomFillerForeachNum] = "F";
                    //ImportantKeysStaticArraysChange("F", IDofAction, _randomFillerForeachNum);
                    return;
                case 6:
                    latters[_randomFillerForeachNum] = "G";
                    //ImportantKeysStaticArraysChange("G", IDofAction, _randomFillerForeachNum);
                    return;
                case 7:
                    latters[_randomFillerForeachNum] = "H";
                    //ImportantKeysStaticArraysChange("H", IDofAction, _randomFillerForeachNum);
                    return;
                case 8:
                    latters[_randomFillerForeachNum] = "I";
                    //ImportantKeysStaticArraysChange("I", IDofAction, _randomFillerForeachNum);
                    return;
                case 9:
                    latters[_randomFillerForeachNum] = "J";
                    //ImportantKeysStaticArraysChange("J", IDofAction, _randomFillerForeachNum);
                    return;
                case 10:
                    latters[_randomFillerForeachNum] = "K";
                    //ImportantKeysStaticArraysChange("K", IDofAction, _randomFillerForeachNum);
                    return;
                case 11:
                    latters[_randomFillerForeachNum] = "L";
                    //ImportantKeysStaticArraysChange("L", IDofAction, _randomFillerForeachNum);
                    return;
                case 12:
                    latters[_randomFillerForeachNum] = "M";
                    //ImportantKeysStaticArraysChange("M", IDofAction, _randomFillerForeachNum);
                    return;
                case 13:
                    latters[_randomFillerForeachNum] = "N";
                    //ImportantKeysStaticArraysChange("N", IDofAction, _randomFillerForeachNum);
                    return;
                case 14:
                    latters[_randomFillerForeachNum] = "O";
                    //ImportantKeysStaticArraysChange("O", IDofAction, _randomFillerForeachNum);
                    return;
                case 15:
                    latters[_randomFillerForeachNum] = "P";
                    //ImportantKeysStaticArraysChange("P", IDofAction, _randomFillerForeachNum);
                    return;
                case 16:
                    latters[_randomFillerForeachNum] = "Q";
                    //ImportantKeysStaticArraysChange("Q", IDofAction, _randomFillerForeachNum);
                    return;
                case 17:
                    latters[_randomFillerForeachNum] = "R";
                    //ImportantKeysStaticArraysChange("R", IDofAction, _randomFillerForeachNum);
                    return;
                case 18:
                    latters[_randomFillerForeachNum] = "S";
                    //ImportantKeysStaticArraysChange("S", IDofAction, _randomFillerForeachNum);
                    return;
                case 19:
                    latters[_randomFillerForeachNum] = "T";
                    //ImportantKeysStaticArraysChange("T", IDofAction, _randomFillerForeachNum);
                    return;
                case 20:
                    latters[_randomFillerForeachNum] = "U";
                    //ImportantKeysStaticArraysChange("U", IDofAction, _randomFillerForeachNum);
                    return;
                case 21:
                    latters[_randomFillerForeachNum] = "V";
                    //ImportantKeysStaticArraysChange("V", IDofAction, _randomFillerForeachNum);
                    return;
                case 22:
                    latters[_randomFillerForeachNum] = "W";
                    //ImportantKeysStaticArraysChange("W", IDofAction, _randomFillerForeachNum);
                    return;
                case 23:
                    latters[_randomFillerForeachNum] = "X";
                    //ImportantKeysStaticArraysChange("X", IDofAction, _randomFillerForeachNum);
                    return;
                case 24:
                    latters[_randomFillerForeachNum] = "Y";
                    //ImportantKeysStaticArraysChange("Y", IDofAction, _randomFillerForeachNum);
                    return;
                case 25:
                    latters[_randomFillerForeachNum] = "Z";
                    //if (currentlyUsedKeys[_randomFillerForeachNum] == false) latters[_randomFillerForeachNum] = "Z";
                    //else isFilledSameLatter = true;
                    //ImportantKeysStaticArraysChange("Z", IDofAction, _randomFillerForeachNum);
                    return;
            }
            //isKeysCheckNeed = true;
            _randomFillerForeachNum++;
        }
        _randomFillerForeachNum = 0;
    }

    public void sequencecsConstantFiller(string[] customArray) //Для ручного заполнения через другие скрипты, добавляешь просто отдельный кастомный массив со своими буквами
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

        //isKeysCheckNeed = true;
    }

    public void OnGUI() //Метод в котором определяется последняя нажатая клавиша
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }

    private void whichLatterToPressCheck(string whichLatter, int posInArray) //Вспомогательный метод, который просто упрощает написание метода whichLatterToPress
    {
        //foreach (var id in keysUsedByActions) //Проверка используется ли нажатая буква в других объектах со скриптом Subsequence и если используется - то скрипт не будет жаловаться, что нажали не на ту кнопку
        //{
        //    foreach(var key in keysUsedByActions[_foreachImportantKeyCheckNum1].Latters)
        //    {
        //        if (keysUsedByActions[_foreachImportantKeyCheckNum1].Latters[_foreachImportantKeyCheckNum2] == whichLatter) 
        //            _isMissJustified = true;
        //        _foreachImportantKeyCheckNum2++;
        //    }
        //    _foreachImportantKeyCheckNum1++;
        //    _foreachImportantKeyCheckNum2 = 0;
        //}
        //_foreachImportantKeyCheckNum1 = 0;
        if (latters[latterNumber] != whichLatter/* && currentlyUsedKeys[posInArray] == false*/) playerMissed = true;

        if (latters[latterNumber] == whichLatter)
        {
            sequences[latterNumber] = true;
            latterNumber++;
        }
        lastPressedKey = KeyCode.Slash; //Это нужно, чтобы игра не запоминала, что нажата данная кнопка и не повторила процесс, если следующая кнопка в массиве совпадает
    }

    //private void ImportantKeysStaticArraysChange(string whichLatter, int IDofAction, int importantKeysArrayPos) //Заполнение массивов, что показывают буквы из всех объектов со скриптом Subsequense.
    //                                                                                                            //IDofAction - это обозначение из какого Subsequence будут взяты буквы для записи в массивы.
    //                                                                                                            //importantKeysArrayPos - это позиция в массиве у буквы для каждого отдельного Subsequence
    //{
    //    //if (keysUsedByActions.Length < IDofAction + 1)
    //    //{
    //    //    Array.Resize(ref keysUsedByActions, IDofAction + 1);
    //    //}
    //    //Array.Resize(ref keysUsedByActions[IDofAction].Latters, importantKeysArrayPos + 1);

    //    //keysUsedByActions[IDofAction].Latters[importantKeysArrayPos] = whichLatter;
        
    //    //foreach (var id in keysUsedByActions)
    //    //{
    //    //    Array.Resize(ref check, keysUsedByActions.Length);
    //    //    foreach (var key in keysUsedByActions[_checkNum1].Latters)
    //    //    {
    //    //        Array.Resize(ref check[_checkNum1].Latters, keysUsedByActions[_checkNum1].Latters.Length);
    //    //        check[_checkNum1].Latters[_checkNum2] = keysUsedByActions[_checkNum1].Latters[_checkNum2];
    //    //        _checkNum2++;
    //    //    }
    //    //    _checkNum1++;
    //    //    _checkNum2 = 0;
    //    //}
    //    //_checkNum1 = 0;
    //}

    //private void ImportantKeysStaticArrayChange()
    //{
    //    if (isKeysCheckNeed == true)
    //    {
    //        foreach (var sucub in importantKeyManager.sucubs)
    //        {
    //            foreach (var id in importantKeyManager.sucubs[_otherSucubsForeachNum1].latters)
    //            {
    //                if (_otherSucubsForeachNum1 != IDOfSequence)
    //                {
    //                    //switch (sucubs[_foreachNum1].latters[_foreachNum2])
    //                    //{
    //                    //    case "A":
    //                    //        _whichKeysNowTrueInOtherSucubs[0] = true;
    //                    //        return;
    //                    //    case "B":
    //                    //        _whichKeysNowTrueInOtherSucubs[1] = true;
    //                    //        return;
    //                    //    case "C":
    //                    //        _whichKeysNowTrueInOtherSucubs[2] = true;
    //                    //        return;
    //                    //    case "D":
    //                    //        _whichKeysNowTrueInOtherSucubs[3] = true;
    //                    //        return;
    //                    //    case "E":
    //                    //        _whichKeysNowTrueInOtherSucubs[4] = true;
    //                    //        return;
    //                    //    case "F":
    //                    //        _whichKeysNowTrueInOtherSucubs[5] = true;
    //                    //        return;
    //                    //    case "G":
    //                    //        _whichKeysNowTrueInOtherSucubs[6] = true;
    //                    //        return;
    //                    //    case "H":
    //                    //        _whichKeysNowTrueInOtherSucubs[7] = true;
    //                    //        return;
    //                    //    case "I":
    //                    //        _whichKeysNowTrueInOtherSucubs[8] = true;
    //                    //        return;
    //                    //    case "J":
    //                    //        _whichKeysNowTrueInOtherSucubs[9] = true;
    //                    //        return;
    //                    //    case "K":
    //                    //        _whichKeysNowTrueInOtherSucubs[10] = true;
    //                    //        return;
    //                    //    case "L":
    //                    //        _whichKeysNowTrueInOtherSucubs[11] = true;
    //                    //        return;
    //                    //    case "M":
    //                    //        _whichKeysNowTrueInOtherSucubs[12] = true;
    //                    //        return;
    //                    //    case "N":
    //                    //        _whichKeysNowTrueInOtherSucubs[13] = true;
    //                    //        return;
    //                    //    case "O":
    //                    //        _whichKeysNowTrueInOtherSucubs[14] = true;
    //                    //        return;
    //                    //    case "P":
    //                    //        _whichKeysNowTrueInOtherSucubs[15] = true;
    //                    //        return;
    //                    //    case "Q":
    //                    //        _whichKeysNowTrueInOtherSucubs[16] = true;
    //                    //        return;
    //                    //    case "R":
    //                    //        _whichKeysNowTrueInOtherSucubs[17] = true;
    //                    //        return;
    //                    //    case "S":
    //                    //        _whichKeysNowTrueInOtherSucubs[18] = true;
    //                    //        return;
    //                    //    case "T":
    //                    //        _whichKeysNowTrueInOtherSucubs[19] = true;
    //                    //        return;
    //                    //    case "U":
    //                    //        _whichKeysNowTrueInOtherSucubs[20] = true;
    //                    //        return;
    //                    //    case "V":
    //                    //        _whichKeysNowTrueInOtherSucubs[21] = true;
    //                    //        return;
    //                    //    case "W":
    //                    //        _whichKeysNowTrueInOtherSucubs[22] = true;
    //                    //        return;
    //                    //    case "X":
    //                    //        _whichKeysNowTrueInOtherSucubs[23] = true;
    //                    //        return;
    //                    //    case "Y":
    //                    //        _whichKeysNowTrueInOtherSucubs[24] = true;
    //                    //        return;
    //                    //    case "Z":
    //                    //        _whichKeysNowTrueInOtherSucubs[25] = true;
    //                    //        return;
    //                    //}
    //                    if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "A") _whichKeysNowTrueInOtherSucubs[0] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "B") _whichKeysNowTrueInOtherSucubs[1] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "C") _whichKeysNowTrueInOtherSucubs[2] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "D") _whichKeysNowTrueInOtherSucubs[3] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "E") _whichKeysNowTrueInOtherSucubs[4] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "F") _whichKeysNowTrueInOtherSucubs[5] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "G") _whichKeysNowTrueInOtherSucubs[6] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "H") _whichKeysNowTrueInOtherSucubs[7] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "I") _whichKeysNowTrueInOtherSucubs[8] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "J") _whichKeysNowTrueInOtherSucubs[9] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "K") _whichKeysNowTrueInOtherSucubs[10] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "L") _whichKeysNowTrueInOtherSucubs[11] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "M") _whichKeysNowTrueInOtherSucubs[12] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "N") _whichKeysNowTrueInOtherSucubs[13] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "O") _whichKeysNowTrueInOtherSucubs[14] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "P") _whichKeysNowTrueInOtherSucubs[15] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Q") _whichKeysNowTrueInOtherSucubs[16] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "R") _whichKeysNowTrueInOtherSucubs[17] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "S") _whichKeysNowTrueInOtherSucubs[18] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "T") _whichKeysNowTrueInOtherSucubs[19] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "U") _whichKeysNowTrueInOtherSucubs[20] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "V") _whichKeysNowTrueInOtherSucubs[21] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "W") _whichKeysNowTrueInOtherSucubs[22] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "X") _whichKeysNowTrueInOtherSucubs[23] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Y") _whichKeysNowTrueInOtherSucubs[24] = true;
    //                    else if (importantKeyManager.sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Z") _whichKeysNowTrueInOtherSucubs[25] = true;
    //                }
    //                _otherSucubsForeachNum2++;
    //            }
    //            _otherSucubsForeachNum1++;
    //            _otherSucubsForeachNum2 = 0;
    //        }
    //        _otherSucubsForeachNum1 = 0;

    //        foreach (var sucub in importantKeyManager.sucubs)
    //        {
    //            foreach (var latter in importantKeyManager.sucubs[_foreachNum1].latters)
    //            {
    //                ImportantKeysCheck("A", 0);
    //                ImportantKeysCheck("B", 1);
    //                ImportantKeysCheck("C", 2);
    //                ImportantKeysCheck("D", 3);
    //                ImportantKeysCheck("E", 4);
    //                ImportantKeysCheck("F", 5);
    //                ImportantKeysCheck("G", 6);
    //                ImportantKeysCheck("H", 7);
    //                ImportantKeysCheck("I", 8);
    //                ImportantKeysCheck("J", 9);
    //                ImportantKeysCheck("K", 10);
    //                ImportantKeysCheck("L", 11);
    //                ImportantKeysCheck("M", 12);
    //                ImportantKeysCheck("N", 13);
    //                ImportantKeysCheck("O", 14);
    //                ImportantKeysCheck("P", 15);
    //                ImportantKeysCheck("Q", 16);
    //                ImportantKeysCheck("R", 17);
    //                ImportantKeysCheck("S", 18);
    //                ImportantKeysCheck("T", 19);
    //                ImportantKeysCheck("U", 20);
    //                ImportantKeysCheck("V", 21);
    //                ImportantKeysCheck("W", 22);
    //                ImportantKeysCheck("X", 23);
    //                ImportantKeysCheck("Y", 24);
    //                ImportantKeysCheck("Z", 25);
    //                _foreachNum2++;
    //            }
    //            _foreachNum1++;
    //            _foreachNum2 = 0;
    //        }
    //        _foreachNum1 = 0;

    //        foreach (var key in _whichKeysNowTrue)
    //        {
    //            _whichKeysNowTrue[_whichKeysTrueForeachNum] = false;
    //            _whichKeysTrueForeachNum++;
    //        }
    //        _whichKeysTrueForeachNum = 0;
    //        foreach (var key in _whichKeysNowTrueInOtherSucubs)
    //        {
    //            _whichKeysNowTrueInOtherSucubs[_whickKeysTrueInOtherForachNum] = false;
    //            _whickKeysTrueInOtherForachNum++;
    //        }
    //        _whickKeysTrueInOtherForachNum = 0;

    //        isKeysCheckNeed = false;
    //    }
    //}

    //private void ImportantKeysCheck(string latter, int posInArray)
    //{
    //    if (_whichKeysNowTrue[posInArray] == false && _whichKeysNowTrueInOtherSucubs[posInArray] == false)
    //    {
    //        if (importantKeyManager.sucubs[_foreachNum1].latters[_foreachNum2] == latter)
    //        {
    //            currentlyUsedKeys[posInArray] = true;
    //            _whichKeysNowTrue[posInArray] = true;
    //        }
    //        else currentlyUsedKeys[posInArray] = false;
    //    }
    //}
}