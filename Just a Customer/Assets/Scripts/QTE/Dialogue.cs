using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //Диалоговое окно с текстом может вылетать только раз. И если игрок ответит - оно уже никогда не вылетит.

    public string words; //Слова, что будут в окне диалога (там не получится написать прям ООООчень много, оке?)
    public string[] lattersToPress; //Это будет обозначать, какие клавиши нужно нажать игроку, чтобы ответить (например: N,O) Писать ток капсом
    public Subsequence sucub; //Субсикуэнс, который опять надо отдельный для этого скрипта
    private bool isDialogueCompleted = false; //Если true - то диалог просто не запустится
    private DialogueManager manager;
    public bool isItHasTrigger; //Диалог хоть и часто, но не всегда имеет триггер

    //Для отключения нанесения урона и возможности двигаться
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
                //Включение нанесения урона
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

    public void dialogueEncounter() //Этот метод публичный, чтобы, если захотеть - можно было включить диалог через другие скрипты
    {
        movementBlock.isMovementBlocked = true;
        //Отключение нанесения урона
        sucub.sequencecsConstantFiller(lattersToPress);
        manager.textObj.text = words;
        manager.dialogueBG.SetActive(true);
        manager.isManagerUsed = true;
    }
}