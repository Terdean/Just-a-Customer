using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public float level; //Можно в инспекторе будет менять для каждого отдельного уровня, чтобы игрок мог сразу начать без дыхалки
    //public float breathLevelDecreaser; //На это значение раз в какое-то время будет уменьшаться уровень моргания
    //public float breathLevelIncreser; //На сколько увеличивается шкала моргания, если нажать на нужную клавишу
    private float againTimer;
    public float againTimerStart; //Время раз в которое будет появляться надобность в нажатии
    private float timeForAction;
    public float startOfTimeForAction; //Время за которое игрок должен нажать появившуюся клавишу
    public GameObject keyObj;
    private bool onlyOneUseOfSucub = false;

    public Subsequence sucub; //Сюда надо добавить тот объект со скриптом Subsequence, который будет отвечать за нужную для нажатия кнопку
    public Text textSign; //Текст, что будет обозначать в интерфейсе нужную для нажатия клавишу
    private float sucubTimer;
    public float sucubTimerStart; //Время раз в которое будет меняться управление
    private bool sucubFirstLatterChange;
    [HideInInspector]
    public ImportantKeysManager importantKeysManager;

    private Vignette vinnipuh;
    [SerializeField]
    private PostProcessVolume volume; //Перетаскиваешь сюды камеру и всё работает
    private float valueMax = 0;
    private float valueCurrent = 0;
    public health PlayerHealth;

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out vinnipuh);
        againTimer = againTimerStart;
        timeForAction = startOfTimeForAction;
    }

    void Update()
    {
        if (!sucubFirstLatterChange) //Рандомно заполнить в начале игры
        {
            sucub.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) sucubFirstLatterChange = true;
        }
        if (sucubTimer > 0) sucubTimer -= Time.deltaTime;
        else
        {
            sucub.sequencesRandomFiller(1);
            importantKeysManager.CheckForSameLatters();
            if (importantKeysManager.isSameLatterFound == false) sucubTimer = sucubTimerStart;
        }

        if (againTimer > 0) againTimer -= Time.deltaTime;
        else
        {
            keyObj.SetActive(true);
            if(!onlyOneUseOfSucub)
            {
                sucubRavager();
                onlyOneUseOfSucub = true;
            }

            if (timeForAction > 0) timeForAction -= Time.deltaTime;
            else //Если не нажмёт
            {
                sucub.sequencesRandomFiller(1);
                importantKeysManager.CheckForSameLatters();
                if (importantKeysManager.isSameLatterFound == false)
                {
                    if (level > -3) level--;

                    keyObj.SetActive(false);
                    againTimer = againTimerStart;
                    timeForAction = startOfTimeForAction;
                    onlyOneUseOfSucub = false;
                }    
            }

            if (sucub.isEverySequencesTrue) //Если нажмёт
            {
                sucub.sequencesRandomFiller(1);
                importantKeysManager.CheckForSameLatters();
                if (importantKeysManager.isSameLatterFound == false)
                {
                    if (level < 3) level++;

                    keyObj.SetActive(false);
                    againTimer = againTimerStart;
                    timeForAction = startOfTimeForAction;
                    onlyOneUseOfSucub = false;

                    sucubRavager();
                }
            }
        }

        //if (breathTimer > 0 && breathLevel >= -100) breathTimer -= Time.deltaTime;
        //else if (breathTimer <= 0 && breathLevel >= -100)
        //{
        //    breathLevel -= breathLevelDecreaser;
        //    breathTimer = breathTimerStart;
        //}

        if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 0.04f;
        if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 0.04f;

        if (level == 0)
        {
            valueMax = 0f;
            vinnipuh.intensity.value = valueCurrent;
            PlayerHealth.Malevich.SetInteger("BreathLevel", 0);
        }
        if (level <= -1)
        {
            valueMax = 0.11f;
            if (level > -2) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (level == -2)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (level == -3)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }
        if (level >= 1)
        {
            valueMax = 0.11f;
            if (level < 2) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (level == 2)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (level == 3)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }

        //if (sucub.isEverySequencesTrue)
        //{
        //    breathLevel += breathLevelIncreser;

        //    sucub.isEverySequencesTrue = false;
        //    foreach (bool i in sucub.sequences)
        //    {
        //        sucub.sequences[_foreachNum] = false;
        //        _foreachNum++;
        //    }
        //    _foreachNum = 0;
        //    sucub.latterNumber = 0;
        //}

        textSign.text = sucub.latters[0] + " - вдох";
    }

    private void sucubRavager()
    {
        sucub.isEverySequencesTrue = false;
        foreach (bool i in sucub.sequences)
        {
            sucub.sequences[_foreachNum] = false;
            _foreachNum++;
        }
        _foreachNum = 0;
        sucub.latterNumber = 0;
    }
}
