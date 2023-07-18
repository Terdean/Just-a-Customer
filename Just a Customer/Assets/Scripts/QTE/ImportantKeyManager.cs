using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ImportantKeyManager : MonoBehaviour
{
    //Смысл этого скрипта прост - может быть игрок и нажмёт на правильную кнопку, но все остальные кнопки сразу посчитают,
    //что он нажал не на них, а значит они обидятся, состроят наглую харю и в isPlayerMissed поставят true.
    //Этот скрипт предназначен для проверки по Всем имеющимся в игре "Важным" для нажатия буквам и если игрок нажмёт на важную,
    //то остальные не будут обижаться.
    //+Этот скрипт можно использовать, чтобы не выбирались одинаковые клавиши для управления, ведь здесь буквально их список.

    //public bool[] currentlyUsedKeys; //Это самый важный тут массив и работает он очень просто - в нём 26 позиций, как в алфавите
    //                                 //и каждая позиция обозначает свою букву в алфавитном порядке. Если позиция = true, то эта
    //                                 //буква используется и другие кнопки не будут обращать внимания, если нажали не на них, а
    
    //public Subsequence[] sucubs; //Надо заполнять в ручную всеми Subsequence, что есть на сцене
    //private bool isIDsAdded;
    //private int IDAddForeachNum;

    //private void Update()
    //{
    //    if(!isIDsAdded)
    //    {
    //        foreach (var sucub in sucubs)
    //        {
    //            sucubs[IDAddForeachNum].IDOfSequence = IDAddForeachNum;
    //            IDAddForeachNum++;
    //        }
    //        IDAddForeachNum = 0;
    //    }
    //}

    //public bool isKeysCheckNeed = true; //Эта переменная меняется через код в Subsequence скриптах.
    //                                    //Этот bool просто чтобы не проверять 60 раз в секунду весь форыч
    //public int IDOfSucub; //Этот ID для чтобы можно было изменять currentlyUsedKeys только от нужного Subsequence

    //private int _foreachNum1 = 0;
    //private int _foreachNum2 = 0;
    //private int _otherSucubsForeachNum1 = 0;
    //private int _otherSucubsForeachNum2 = 0;
    //private bool[] _whichKeysNowTrue;
    //private int _whichKeysTrueForeachNum;
    //private bool[] _whichKeysNowTrueInOtherSucubs;
    //private int _whickKeysTrueInOtherForachNum;

    //private void Start()
    //{
    //    Array.Resize(ref currentlyUsedKeys, 26);
    //    Array.Resize(ref _whichKeysNowTrue, 26);
    //    Array.Resize(ref _whichKeysNowTrueInOtherSucubs, 26);
    //}

    //void Update()
    //{
    //    if (isKeysCheckNeed == true)
    //    {
    //        foreach (var sucub in sucubs)
    //        {
    //            foreach (var id in sucubs[_otherSucubsForeachNum1].latters)
    //            {
    //                if (_otherSucubsForeachNum1 != IDOfSucub)
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
    //                    if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "A") _whichKeysNowTrueInOtherSucubs[0] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "B") _whichKeysNowTrueInOtherSucubs[1] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "C") _whichKeysNowTrueInOtherSucubs[2] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "D") _whichKeysNowTrueInOtherSucubs[3] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "E") _whichKeysNowTrueInOtherSucubs[4] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "F") _whichKeysNowTrueInOtherSucubs[5] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "G") _whichKeysNowTrueInOtherSucubs[6] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "H") _whichKeysNowTrueInOtherSucubs[7] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "I") _whichKeysNowTrueInOtherSucubs[8] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "J") _whichKeysNowTrueInOtherSucubs[9] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "K") _whichKeysNowTrueInOtherSucubs[10] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "L") _whichKeysNowTrueInOtherSucubs[11] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "M") _whichKeysNowTrueInOtherSucubs[12] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "N") _whichKeysNowTrueInOtherSucubs[13] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "O") _whichKeysNowTrueInOtherSucubs[14] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "P") _whichKeysNowTrueInOtherSucubs[15] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Q") _whichKeysNowTrueInOtherSucubs[16] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "R") _whichKeysNowTrueInOtherSucubs[17] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "S") _whichKeysNowTrueInOtherSucubs[18] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "T") _whichKeysNowTrueInOtherSucubs[19] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "U") _whichKeysNowTrueInOtherSucubs[20] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "V") _whichKeysNowTrueInOtherSucubs[21] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "W") _whichKeysNowTrueInOtherSucubs[22] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "X") _whichKeysNowTrueInOtherSucubs[23] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Y") _whichKeysNowTrueInOtherSucubs[24] = true;
    //                    else if (sucubs[_otherSucubsForeachNum1].latters[_otherSucubsForeachNum2] == "Z") _whichKeysNowTrueInOtherSucubs[25] = true;
    //                }
    //                _otherSucubsForeachNum2++;
    //            }
    //            _otherSucubsForeachNum1++;
    //            _otherSucubsForeachNum2 = 0;
    //        }
    //        _otherSucubsForeachNum1 = 0;

    //        foreach (var sucub in sucubs)
    //        {
    //            foreach (var latter in sucubs[_foreachNum1].latters)
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
    //        if (sucubs[_foreachNum1].latters[_foreachNum2] == latter)
    //        {
    //            currentlyUsedKeys[posInArray] = true;
    //            _whichKeysNowTrue[posInArray] = true;
    //        }
    //        else currentlyUsedKeys[posInArray] = false;
    //    }
    //}
}