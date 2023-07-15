using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsequence : MonoBehaviour
{
    //Ётот скрипт будет накладыватьс€ дл€ каждого отдельного места, где нужно нажимать последовательно кнопки
    //и нужно будет чекать через другой скрипт, €вл€етс€ ли isEverySequencesTrue = true. » там уже
    //в другом скрипте должно сто€ть нужное вам условие, мол ≈сли(isEverySequencesTrue == true), то выполн€ем код.
    //“ак же в скрипте есть два метода интересных: sequencesRandomFiller и sequencecsConstantFiller их можно юзать
    //дл€ заполнени€ массивов нужными буквами при помощи скриптов из вне.

    public bool[] sequences; //≈сли true - значит кнопка нажата, если false - значит не нажата
    public string[] latters; //—писок букв, которые нужно нажать. Ётот и массив выше должны быть одинакового размера. Ѕуквы строго капсом!
    public int latterNumber; //Ёту переменную нужно обнул€ть через другие скрипты по выполнении всех действий

    public bool isEverySequencesTrue; //Ёто сама€ важна€ финальна€ переменна€ - ≈сли все буквы нажаты в правильном пор€дке
                                      //Ќо не забывайте эту переменную в других скриптах делать false, когда код сделалс€.
    public bool playerMissed; //Ёта переменна€ не об€зательно должна использоватьс€. Ќо у неЄ работа, как у isEverySequencesTrue
                              //Ќо не забывайте эту переменную в других скриптах делать false, когда код сделалс€.

    private KeyCode lastPressedKey;

    private int numForeach = 0; //“ут куча вспомогательных переменных, просто тыкните на них и поймЄте дл€ чего они нужны
    private int randomFillerForeachNum = 0;
    private int constantFillerForeachNum = 0;
    private int randomLatter;

    void Update()
    {
        whichLatterToPress();

        foreach (bool i in sequences) //ѕроверка сколько клавиш правильно нажато 
        {
            if (sequences[numForeach] == true) numForeach++;

            if (numForeach >= sequences.Length) isEverySequencesTrue = true;
        }
        numForeach = 0;
    }

    public void Checkanie()
    {
        isEverySequencesTrue = true;
    }

    public void whichLatterToPress() //„ек совпадает ли нажата€ клавиша с нужной клавишей дл€ нажати€
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
                    lastPressedKey = KeyCode.Slash; //Ёто нужно, чтобы игра не запоминала, что нажата данна€ кнопка и не повторила процесс, если следующа€ кнопка в массиве совпадает

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

    public void sequencesRandomFiller(int latterCount) //Ётот метод должен юзатьс€ через другие скрипты, дл€ рандомного заполнени€ двух наших массивов
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
                    latters[randomFillerForeachNum] = "A";
                    return;
                case 1:
                    latters[randomFillerForeachNum] = "B";
                    return;
                case 2:
                    latters[randomFillerForeachNum] = "C";
                    return;
                case 3:
                    latters[randomFillerForeachNum] = "D";
                    return;
                case 4:
                    latters[randomFillerForeachNum] = "E";
                    return;
                case 5:
                    latters[randomFillerForeachNum] = "F";
                    return;
                case 6:
                    latters[randomFillerForeachNum] = "G";
                    return;
                case 7:
                    latters[randomFillerForeachNum] = "H";
                    return;
                case 8:
                    latters[randomFillerForeachNum] = "I";
                    return;
                case 9:
                    latters[randomFillerForeachNum] = "J";
                    return;
                case 10:
                    latters[randomFillerForeachNum] = "K";
                    return;
                case 11:
                    latters[randomFillerForeachNum] = "L";
                    return;
                case 12:
                    latters[randomFillerForeachNum] = "M";
                    return;
                case 13:
                    latters[randomFillerForeachNum] = "N";
                    return;
                case 14:
                    latters[randomFillerForeachNum] = "O";
                    return;
                case 15:
                    latters[randomFillerForeachNum] = "P";
                    return;
                case 16:
                    latters[randomFillerForeachNum] = "Q";
                    return;
                case 17:
                    latters[randomFillerForeachNum] = "R";
                    return;
                case 18:
                    latters[randomFillerForeachNum] = "S";
                    return;
                case 19:
                    latters[randomFillerForeachNum] = "T";
                    return;
                case 20:
                    latters[randomFillerForeachNum] = "U";
                    return;
                case 21:
                    latters[randomFillerForeachNum] = "V";
                    return;
                case 22:
                    latters[randomFillerForeachNum] = "W";
                    return;
                case 23:
                    latters[randomFillerForeachNum] = "X";
                    return;
                case 24:
                    latters[randomFillerForeachNum] = "Y";
                    return;
                case 25:
                    latters[randomFillerForeachNum] = "Z";
                    return;
            }

            randomFillerForeachNum++;
        }
        randomFillerForeachNum = 0;
    }

    public void sequencecsConstantFiller(string[] customArray) //ƒл€ ручного заполнени€ через другие скрипты, добавл€ешь просто отдельный кастомный массив со своими буквами
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

    public void OnGUI() //ћетод в котором определ€етс€ последн€€ нажата€ клавиша
    {
        if (Event.current.isKey) lastPressedKey = Event.current.keyCode;
    }
}
