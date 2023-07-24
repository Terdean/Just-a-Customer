using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public float blinkLevel; //Можно в инспекторе будет менять для каждого отдельного уровня, чтобы игрок мог сразу начать без глаз О-О
    public float blinkLevelDecreaser; //На это значение раз в какое-то время будет уменьшаться уровень моргания
    public float blinkLevelIncreser; //На сколько увеличивается шкала моргания, если нажать на нужную клавишу
    private float blinkTimer;
    public float blinkTimerStart; //Время раз в которое будет уменьшаться уровень моргания

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
    private float valueCurrent = 50;

    private int _foreachNum;

    private void Start()
    {
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        volume.profile.TryGetSettings(out blur);
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

        if (blinkTimer > 0 && blinkLevel >= -100) blinkTimer -= Time.deltaTime;
        else
        {
            blinkLevel -= blinkLevelDecreaser;
            blinkTimer = blinkTimerStart;
        }

        if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 10;
        if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 10;
        
        if (blinkLevel > -20 && blinkLevel < 70)
        {
            valueMax = 50;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -20)
        {
            valueMax = 100;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -50)
        {
            valueMax = 200;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel <= -80)
        {
            valueMax = 300;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 70)
        {
            valueMax = 100;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 80)
        {
            valueMax = 200;
            blur.focalLength.value = valueCurrent;
        }
        if (blinkLevel >= 90)
        {
            valueMax = 300;
            blur.focalLength.value = valueCurrent;
        }

        if (sucub.isEverySequencesTrue)
        {
            blinkLevel += blinkLevelIncreser;

            sucub.isEverySequencesTrue = false;
            foreach (bool i in sucub.sequences)
            {
                sucub.sequences[_foreachNum] = false;
                _foreachNum++;
            }
            _foreachNum = 0;
            sucub.latterNumber = 0;
        }

        textSign.text = sucub.latters[0] + " - моргание";
    }
}