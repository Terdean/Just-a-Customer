using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantKeyManager : MonoBehaviour
{
    //Смысл этого скрипта прост - может быть игрок и нажмёт на правильную кнопку, но все остальные кнопки сразу посчитают,
    //что он нажал не на них, а значит они обидятся, состроят наглую харю и в isPlayerMissed поставят true.
    //Этот скрипт предназначен для проверки по Всем имеющимся в игре "Важным" для нажатия буквам и если игрок нажмёт на важную,
    //то остальные не будут обижаться.
    //+Этот скрипт можно использовать, чтобы не выбирались одинаковые клавиши для управления, ведь здесь буквально их список.

    public string[] ImportantKeys;

    void Update()
    {
        
    }

    public void AddKeyToArray()
    {

    }
}
