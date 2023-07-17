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

    [Header("Settings only for this Sequence")]
    public bool[] sequences; //Если true - значит кнопка нажата, если false - значит не нажата
    public string[] latters; //Список букв, которые нужно нажать. Этот и массив выше должны быть одинакового размера. Буквы строго капсом!
    [HideInInspector]
    public int latterNumber; //Номер буквы нужной сейчас для нажатия. Эту переменную нужно обнулять через другие скрипты по выполнении всех действий

    public bool isEverySequencesTrue; //Это самая важная финальная переменная - Если все буквы нажаты в правильном порядке
                                      //Но не забывайте эту переменную в других скриптах делать false, когда код сделался.
    public bool playerMissed; //Эта переменная не обязательно должна использоваться. Но у неё работа, как у isEverySequencesTrue
                              //Но не забывайте эту переменную в других скриптах делать false, когда код сделался.

    [Header("Settings of all Sequences")]
    public int idOfAction;
    private bool isIdOfActionUsed = false;
    static bool[] currentlyUsedKeys;
    public CurrentlyUsedKeys[] keysUsedByActions; //Статичный массив вообще всех требуемых для управления букв.
                                                  //Вообще всех - значит из всех вообще применений скрипта Subsequence в игре.
                                                  //Благодаря этом массиву была оптимизированна огромная часть игры :О
    public CurrentlyUsedKeys[] check;

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

    void Update()
    {
        if (!isIdOfActionUsed) //Для заполнения общего массива, если Subsequence заполняется вручную
        {
            foreach (var latter in latters)
            {
                ImportantKeysStaticArraysChange(latters[_starterForeachNum], idOfAction, _starterForeachNum);
                _starterForeachNum++;
            }
            _starterForeachNum = 0;
            isIdOfActionUsed = true;
        }

        whichLatterToPress();

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
                    whichLatterToPressCheck("A");
                    return;
                case KeyCode.B:
                    whichLatterToPressCheck("B");
                    return;
                case KeyCode.C:
                    whichLatterToPressCheck("C");
                    return;
                case KeyCode.D:
                    whichLatterToPressCheck("D");
                    return;
                case KeyCode.E:
                    whichLatterToPressCheck("E");
                    return;
                case KeyCode.F:
                    whichLatterToPressCheck("F");
                    return;
                case KeyCode.G:
                    whichLatterToPressCheck("G");
                    return;
                case KeyCode.H:
                    whichLatterToPressCheck("H");
                    return;
                case KeyCode.I:
                    whichLatterToPressCheck("I");
                    return;
                case KeyCode.J:
                    whichLatterToPressCheck("J");
                    return;
                case KeyCode.K:
                    whichLatterToPressCheck("K");
                    return;
                case KeyCode.L:
                    whichLatterToPressCheck("L");
                    return;
                case KeyCode.M:
                    whichLatterToPressCheck("M");
                    return;
                case KeyCode.N:
                    whichLatterToPressCheck("N");
                    return;
                case KeyCode.O:
                    whichLatterToPressCheck("O");
                    return;
                case KeyCode.P:
                    whichLatterToPressCheck("P");
                    return;
                case KeyCode.Q:
                    whichLatterToPressCheck("Q");
                    return;
                case KeyCode.R:
                    whichLatterToPressCheck("R");
                    return;
                case KeyCode.S:
                    whichLatterToPressCheck("S");
                    return;
                case KeyCode.T:
                    whichLatterToPressCheck("T");
                    return;
                case KeyCode.U:
                    whichLatterToPressCheck("U");
                    return;
                case KeyCode.V:
                    whichLatterToPressCheck("V");
                    return;
                case KeyCode.W:
                    whichLatterToPressCheck("W");
                    return;
                case KeyCode.X:
                    whichLatterToPressCheck("X");
                    return;
                case KeyCode.Y:
                    whichLatterToPressCheck("Y");
                    return;
                case KeyCode.Z:
                    whichLatterToPressCheck("Z");
                    return;
            }
        }
    }

    public void sequencesRandomFiller(int latterCount, int IDofAction) //Этот метод должен юзаться через другие скрипты, для рандомного заполнения двух наших массивов
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
                    ImportantKeysStaticArraysChange("A", IDofAction, _randomFillerForeachNum);
                    return;
                case 1:
                    latters[_randomFillerForeachNum] = "B";
                    ImportantKeysStaticArraysChange("B", IDofAction, _randomFillerForeachNum);
                    return;
                case 2:
                    latters[_randomFillerForeachNum] = "C";
                    ImportantKeysStaticArraysChange("C", IDofAction, _randomFillerForeachNum);
                    return;
                case 3:
                    latters[_randomFillerForeachNum] = "D";
                    ImportantKeysStaticArraysChange("D", IDofAction, _randomFillerForeachNum);
                    return;
                case 4:
                    latters[_randomFillerForeachNum] = "E";
                    ImportantKeysStaticArraysChange("E", IDofAction, _randomFillerForeachNum);
                    return;
                case 5:
                    latters[_randomFillerForeachNum] = "F";
                    ImportantKeysStaticArraysChange("F", IDofAction, _randomFillerForeachNum);
                    return;
                case 6:
                    latters[_randomFillerForeachNum] = "G";
                    ImportantKeysStaticArraysChange("G", IDofAction, _randomFillerForeachNum);
                    return;
                case 7:
                    latters[_randomFillerForeachNum] = "H";
                    ImportantKeysStaticArraysChange("H", IDofAction, _randomFillerForeachNum);
                    return;
                case 8:
                    latters[_randomFillerForeachNum] = "I";
                    ImportantKeysStaticArraysChange("I", IDofAction, _randomFillerForeachNum);
                    return;
                case 9:
                    latters[_randomFillerForeachNum] = "J";
                    ImportantKeysStaticArraysChange("J", IDofAction, _randomFillerForeachNum);
                    return;
                case 10:
                    latters[_randomFillerForeachNum] = "K";
                    ImportantKeysStaticArraysChange("K", IDofAction, _randomFillerForeachNum);
                    return;
                case 11:
                    latters[_randomFillerForeachNum] = "L";
                    ImportantKeysStaticArraysChange("L", IDofAction, _randomFillerForeachNum);
                    return;
                case 12:
                    latters[_randomFillerForeachNum] = "M";
                    ImportantKeysStaticArraysChange("M", IDofAction, _randomFillerForeachNum);
                    return;
                case 13:
                    latters[_randomFillerForeachNum] = "N";
                    ImportantKeysStaticArraysChange("N", IDofAction, _randomFillerForeachNum);
                    return;
                case 14:
                    latters[_randomFillerForeachNum] = "O";
                    ImportantKeysStaticArraysChange("O", IDofAction, _randomFillerForeachNum);
                    return;
                case 15:
                    latters[_randomFillerForeachNum] = "P";
                    ImportantKeysStaticArraysChange("P", IDofAction, _randomFillerForeachNum);
                    return;
                case 16:
                    latters[_randomFillerForeachNum] = "Q";
                    ImportantKeysStaticArraysChange("Q", IDofAction, _randomFillerForeachNum);
                    return;
                case 17:
                    latters[_randomFillerForeachNum] = "R";
                    ImportantKeysStaticArraysChange("R", IDofAction, _randomFillerForeachNum);
                    return;
                case 18:
                    latters[_randomFillerForeachNum] = "S";
                    ImportantKeysStaticArraysChange("S", IDofAction, _randomFillerForeachNum);
                    return;
                case 19:
                    latters[_randomFillerForeachNum] = "T";
                    ImportantKeysStaticArraysChange("T", IDofAction, _randomFillerForeachNum);
                    return;
                case 20:
                    latters[_randomFillerForeachNum] = "U";
                    ImportantKeysStaticArraysChange("U", IDofAction, _randomFillerForeachNum);
                    return;
                case 21:
                    latters[_randomFillerForeachNum] = "V";
                    ImportantKeysStaticArraysChange("V", IDofAction, _randomFillerForeachNum);
                    return;
                case 22:
                    latters[_randomFillerForeachNum] = "W";
                    ImportantKeysStaticArraysChange("W", IDofAction, _randomFillerForeachNum);
                    return;
                case 23:
                    latters[_randomFillerForeachNum] = "X";
                    ImportantKeysStaticArraysChange("X", IDofAction, _randomFillerForeachNum);
                    return;
                case 24:
                    latters[_randomFillerForeachNum] = "Y";
                    ImportantKeysStaticArraysChange("Y", IDofAction, _randomFillerForeachNum);
                    return;
                case 25:
                    latters[_randomFillerForeachNum] = "Z";
                    ImportantKeysStaticArraysChange("Z", IDofAction, _randomFillerForeachNum);
                    return;
            }

            _randomFillerForeachNum++;
        }
        _randomFillerForeachNum = 0;
    }

    public void sequencecsConstantFiller(string[] customArray, int IDofAction) //Для ручного заполнения через другие скрипты, добавляешь просто отдельный кастомный массив со своими буквами
    {
        Array.Resize(ref sequences, customArray.Length);
        Array.Resize(ref latters, customArray.Length);

        foreach (string latter in customArray)
        {
            sequences[_constantFillerForeachNum] = false;

            latters[_constantFillerForeachNum] = customArray[_constantFillerForeachNum];
            ImportantKeysStaticArraysChange(customArray[_constantFillerForeachNum], IDofAction, _constantFillerForeachNum);
            _constantFillerForeachNum++;
        }
        _constantFillerForeachNum = 0;
    }

    public void OnGUI() //Метод в котором определяется последняя нажатая клавиша
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }

    private void whichLatterToPressCheck(string whichLatter) //Вспомогательный метод, который просто упрощает написание метода whichLatterToPress
    {
        foreach (var id in keysUsedByActions) //Проверка используется ли нажатая буква в других объектах со скриптом Subsequence и если используется - то скрипт не будет жаловаться, что нажали не на ту кнопку
        {
            foreach(var key in keysUsedByActions[_foreachImportantKeyCheckNum1].Latters)
            {
                if (keysUsedByActions[_foreachImportantKeyCheckNum1].Latters[_foreachImportantKeyCheckNum2] == whichLatter) 
                    _isMissJustified = true;
                _foreachImportantKeyCheckNum2++;
            }
            _foreachImportantKeyCheckNum1++;
            _foreachImportantKeyCheckNum2 = 0;
        }
        _foreachImportantKeyCheckNum1 = 0;
        if (latters[latterNumber] != whichLatter && _isMissJustified == false) playerMissed = true;
        _isMissJustified = false;

        if (latters[latterNumber] == whichLatter)
        {
            sequences[latterNumber] = true;
            latterNumber++;
        }
        lastPressedKey = KeyCode.Slash; //Это нужно, чтобы игра не запоминала, что нажата данная кнопка и не повторила процесс, если следующая кнопка в массиве совпадает
    }

    private void ImportantKeysStaticArraysChange(string whichLatter, int IDofAction, int importantKeysArrayPos) //Заполнение массивов, что показывают буквы из всех объектов со скриптом Subsequense.
                                                                                                                //IDofAction - это обозначение из какого Subsequence будут взяты буквы для записи в массивы.
                                                                                                                //importantKeysArrayPos - это позиция в массиве у буквы для каждого отдельного Subsequence
    {
        if (keysUsedByActions.Length < IDofAction + 1)
        {
            Array.Resize(ref keysUsedByActions, IDofAction + 1);
        }
        Array.Resize(ref keysUsedByActions[IDofAction].Latters, importantKeysArrayPos + 1);

        keysUsedByActions[IDofAction].Latters[importantKeysArrayPos] = whichLatter;
        
        foreach (var id in keysUsedByActions)
        {
            Array.Resize(ref check, keysUsedByActions.Length);
            foreach (var key in keysUsedByActions[_checkNum1].Latters)
            {
                Array.Resize(ref check[_checkNum1].Latters, keysUsedByActions[_checkNum1].Latters.Length);
                check[_checkNum1].Latters[_checkNum2] = keysUsedByActions[_checkNum1].Latters[_checkNum2];
                _checkNum2++;
            }
            _checkNum1++;
            _checkNum2 = 0;
        }
        _checkNum1 = 0;
    }
}