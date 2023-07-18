using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantKeysManager : MonoBehaviour
{
    private KeyCode lastPressedKey;
    public Subsequence[] sucubs; //Заполнять надо в ручную Всеми Subsequence скриптами, что есть на сцене
    private bool playerActuallyNotMissed;

    //[HideInInspector]
    public bool isSameLatterFound = false;

    //Тут куча вспомогательных переменных, просто тыкните на них и поймёте для чего они нужны
    private int _sameLatterForeachNum1;
    private int _sameLatterForeachNum2;
    private int _sameLatterForeachNum3;
    private int _sameLatterForeachNum4;
    private int _missingCheckForeachNum1;
    private int _missingCheckForeachNum2;
    private int _missingCheckForeachNum3;

    public void CheckForSameLatters() //Проверка есть ли у скриптов Subsequence одинаковые клавиши
    {
        foreach (var sucub in sucubs)
        {
            foreach (var latter in sucubs[_sameLatterForeachNum1].latters)
            {
                foreach (var sucubToCheck in sucubs)
                {
                    foreach (var latterTocheck in sucubs[_sameLatterForeachNum3].latters)
                    {
                        if (_missingCheckForeachNum1 != _missingCheckForeachNum3)
                        {
                            if (sucubs[_sameLatterForeachNum1].latters[_sameLatterForeachNum2]
                            == sucubs[_sameLatterForeachNum3].latters[_sameLatterForeachNum4])
                            {
                                isSameLatterFound = true;
                                break;
                            }
                            else if (sucubs[_sameLatterForeachNum1].latters[_sameLatterForeachNum2]
                                != sucubs[_sameLatterForeachNum3].latters[_sameLatterForeachNum4])
                            {
                                isSameLatterFound = false;
                            }
                        }
                        _sameLatterForeachNum4++;
                    }
                    if (isSameLatterFound) break;
                    _sameLatterForeachNum3++;
                    _sameLatterForeachNum4 = 0;
                }
                if (isSameLatterFound) break;
                _sameLatterForeachNum2++;
                _sameLatterForeachNum3 = 0;
            }
            if (isSameLatterFound) break;
            _sameLatterForeachNum1++;
            _sameLatterForeachNum2 = 0;
        }
        _sameLatterForeachNum1 = 0;
    }

    public void MissingCheck() //Метод нужен, чтобы игра не защитывала промохи, ведь даже при правильном нажатии на кнопку - у остольных это засчитает, как неверное нажатие. Так вот это фиксится тут
    {
        switch (lastPressedKey)
        {
            case KeyCode.A:
                MissingCheckMainComponent("A");
                return;
            case KeyCode.B:
                MissingCheckMainComponent("B");
                return;
            case KeyCode.C:
                MissingCheckMainComponent("C");
                return;
            case KeyCode.D:
                MissingCheckMainComponent("D");
                return;
            case KeyCode.E:
                MissingCheckMainComponent("E");
                return;
            case KeyCode.F:
                MissingCheckMainComponent("F");
                return;
            case KeyCode.G:
                MissingCheckMainComponent("G");
                return;
            case KeyCode.H:
                MissingCheckMainComponent("H");
                return;
            case KeyCode.I:
                MissingCheckMainComponent("I");
                return;
            case KeyCode.J:
                MissingCheckMainComponent("J");
                return;
            case KeyCode.K:
                MissingCheckMainComponent("K");
                return;
            case KeyCode.L:
                MissingCheckMainComponent("L");
                return;
            case KeyCode.M:
                MissingCheckMainComponent("M");
                return;
            case KeyCode.N:
                MissingCheckMainComponent("N");
                return;
            case KeyCode.O:
                MissingCheckMainComponent("O");
                return;
            case KeyCode.P:
                MissingCheckMainComponent("P");
                return;
            case KeyCode.Q:
                MissingCheckMainComponent("Q");
                return;
            case KeyCode.R:
                MissingCheckMainComponent("R");
                return;
            case KeyCode.S:
                MissingCheckMainComponent("S");
                return;
            case KeyCode.T:
                MissingCheckMainComponent("T");
                return;
            case KeyCode.U:
                MissingCheckMainComponent("U");
                return;
            case KeyCode.V:
                MissingCheckMainComponent("V");
                return;
            case KeyCode.W:
                MissingCheckMainComponent("W");
                return;
            case KeyCode.X:
                MissingCheckMainComponent("X");
                return;
            case KeyCode.Y:
                MissingCheckMainComponent("Y");
                return;
            case KeyCode.Z:
                MissingCheckMainComponent("Z");
                return;
        }
    }

    private void MissingCheckMainComponent(string latter) //Вспомогательный метод, который просто упрощает написание кода
    {
        foreach (var sucub in sucubs) //Проверка промохнулся ли игрок на самом деле или нет
        {
            foreach (var key in sucubs[_missingCheckForeachNum1].latters)
            {
                if (sucubs[_missingCheckForeachNum1].latters[_missingCheckForeachNum2] == latter) playerActuallyNotMissed = true;
                _missingCheckForeachNum2++;
            }
            _missingCheckForeachNum1++;
            _missingCheckForeachNum2 = 0;
        }
        _missingCheckForeachNum1 = 0;

        if (playerActuallyNotMissed) //Отклюение playerMissed у всех классов, если игрок всё правильно нажад
        {
            playerActuallyNotMissed = false;

            foreach (var sucub in sucubs)
            {
                sucubs[_missingCheckForeachNum3].playerMissed = false;
                _missingCheckForeachNum3++;
            }
            _missingCheckForeachNum3 = 0;
        }
    }

    public void OnGUI() //Метод в котором определяется последняя нажатая клавиша
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }
}
