using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public float breathLevel; //Можно в инспекторе будет менять для каждого отдельного уровня, чтобы игрок мог сразу начать без глаз О-О
    public float breathLevelDecreaser; //На это значение раз в какое-то время будет уменьшаться уровень моргания
    public float breathLevelIncreser; //На сколько увеличивается шкала моргания, если нажать на нужную клавишу
    private float breathTimer;
    public float breathTimerStart; //Время раз в которое будет уменьшаться уровень моргания

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

        if (breathTimer > 0 && breathLevel >= -100) breathTimer -= Time.deltaTime;
        else if (breathTimer <= 0 && breathLevel >= -100)
        {
            breathLevel -= breathLevelDecreaser;
            breathTimer = breathTimerStart;
        }

        if (valueCurrent < valueMax) valueCurrent += Time.deltaTime * 0.01f;
        if (valueCurrent > valueMax) valueCurrent -= Time.deltaTime * 0.01f;

        if (breathLevel > -20 && breathLevel < 70)
        {
            valueMax = 0f;
            vinnipuh.intensity.value = valueCurrent;
        }
        if (breathLevel <= -20)
        {
            valueMax = 0.11f;
            if (breathLevel > -50) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (breathLevel <= -50)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (breathLevel <= -80)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }
        if (breathLevel >= 70)
        {
            valueMax = 0.11f;
            if (breathLevel < 80) PlayerHealth.Malevich.SetInteger("BreathLevel", 1);
            if (breathLevel >= 80)
            {
                valueMax = 0.22f;
                PlayerHealth.hp_minus(Time.deltaTime);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 2);
            }
            if (breathLevel >= 90)
            {
                valueMax = 0.33f;
                PlayerHealth.hp_minus(Time.deltaTime * 2);
                PlayerHealth.Malevich.SetInteger("BreathLevel", 3);
            }
            vinnipuh.intensity.value = valueCurrent;
        }

        if (sucub.isEverySequencesTrue)
        {
            breathLevel += breathLevelIncreser;

            sucub.isEverySequencesTrue = false;
            foreach (bool i in sucub.sequences)
            {
                sucub.sequences[_foreachNum] = false;
                _foreachNum++;
            }
            _foreachNum = 0;
            sucub.latterNumber = 0;
        }

        textSign.text = sucub.latters[0] + " - вдох";
    }
}
