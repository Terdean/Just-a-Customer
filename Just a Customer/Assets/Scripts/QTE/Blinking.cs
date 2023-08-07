using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public float level; //Можно в инспекторе будет менять для каждого отдельного уровня, чтобы игрок мог сразу начать без глаз О-О
    //public float blinkLevelDecreaser; //На это значение раз в какое-то время будет уменьшаться уровень моргания
    //public float blinkLevelIncreser; //На сколько увеличивается шкала моргания, если нажать на нужную клавишу
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

    private DepthOfField blur;
    [SerializeField]
    private PostProcessVolume volume; //Перетаскиваешь сюды камеру и всё работает
    private float valueMax = 50;
    public float valueCurrent = 50;
    public health PlayerHealth;
    private bool blurRiseNeed; //Это чтобы блюр не стоял постоянно и как-бы набывал и уходил и заново.
                               //Если false - valueCurrent идёт к 50, если true - valueCurrent идёт к valueMax

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out blur);
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

        if (againTimer > 0) againTimer -= Time.deltaTime;
        else
        {
            keyObj.SetActive(true);
            if (!onlyOneUseOfSucub)
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

        //if (!sucubFirstLatterChange) //Рандомно заполнить в начале игры
        //{
        //    sucub.sequencesRandomFiller(1);

        //    importantKeysManager.CheckForSameLatters();
        //    if (importantKeysManager.isSameLatterFound == false) sucubFirstLatterChange = true;
        //}
        //if (sucubTimer > 0) sucubTimer -= Time.deltaTime;
        //else
        //{
        //    sucub.sequencesRandomFiller(1);
        //    importantKeysManager.CheckForSameLatters();
        //    if (importantKeysManager.isSameLatterFound == false) sucubTimer = sucubTimerStart;
        //}

        //if (blinkTimer > 0 && blinkLevel >= -100) blinkTimer -= Time.deltaTime;
        //else if (blinkTimer <= 0 && blinkLevel >= -100)
        //{
        //    blinkLevel -= blinkLevelDecreaser;
        //    blinkTimer = blinkTimerStart;
        //}

        //if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 30;
        //if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 30;
        blurRising();


        if (level == 0)
        {
            valueMax = 50;
            blur.focalLength.value = valueCurrent;
        }
        if (level <= -1)
        {
            valueMax = 100;
            if (level == -2)
            {
                valueMax = 200;
                PlayerHealth.hp_minus(Time.deltaTime);
            }
            if (level == -3)
            {
                valueMax = 300;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
            }
            blur.focalLength.value = valueCurrent;
        }
        if (level >= 1)
        {
            valueMax = 100;
            if (level == 2)
            {
                valueMax = 200;
                PlayerHealth.hp_minus(Time.deltaTime);
            }
            if (level == 3)
            {
                valueMax = 300;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
            }
            blur.focalLength.value = valueCurrent;
        }

        //if (sucub.isEverySequencesTrue)
        //{
        //    blinkLevel += blinkLevelIncreser;

        //    sucub.isEverySequencesTrue = false;
        //    foreach (bool i in sucub.sequences)
        //    {
        //        sucub.sequences[_foreachNum] = false;
        //        _foreachNum++;
        //    }
        //    _foreachNum = 0;
        //    sucub.latterNumber = 0;
        //}

        textSign.text = sucub.latters[0] + " - моргание";
    }

    private void sucubRavager()
    {
        foreach (bool i in sucub.sequences)
        {
            sucub.sequences[_foreachNum] = false;
            _foreachNum++;
        }
        _foreachNum = 0;
        sucub.isEverySequencesTrue = false;
        sucub.latterNumber = 0;
    }

    private void blurRising() //Это чтобы блюр не стоял постоянно и как-бы набывал и уходил и заново.
    {
        if(valueMax > 50 && blurRiseNeed)
        {
            if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 45;
            if (valueCurrent >= valueMax) blurRiseNeed = false;
        }
        if(!blurRiseNeed)
        {
            if (valueCurrent > 50) valueCurrent -= Time.deltaTime * 45;
            else blurRiseNeed = true;
        }    
    }
}