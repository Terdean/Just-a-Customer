using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAttack : MonoBehaviour
{
    //Накладывать этот скрипт надо на дочерний игроку объект у которого будет триггер и если в него войдут окружающие - то всё будет работать

    //private GameObject player;
    private ImportantKeysManager importantKeysManager;
    public Subsequence sucub;
    public GameObject[] keys;
    public int numberOfLatters;
    public hitByCustomersTrigger hitTrigger;

    [HideInInspector]
    public bool isPlayerDodged = false; //Если true - то игрок не сможет столкнуться с другими покупателями
    private float dodgeResetTimer;
    public float dodgeResetTimerStart;

    private int _foreachKeyObjNum;
    private bool _sucubFirstLatterChange = false;
    private int _sucubSequenceNumber = 0;
    private int _twoInOne = 0;
    private int _sucubRevagerForeachNum = 0;

    void Start()
    {
        isPlayerDodged = false;
        dodgeResetTimer = dodgeResetTimerStart;
        importantKeysManager = GameObject.Find("ImportantKeysManager").GetComponent<ImportantKeysManager>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            _twoInOne++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer" && !isPlayerDodged)
        {
            if (!_sucubFirstLatterChange)
            {
                foreach (var keyObject in keys)
                {
                    keys[_foreachKeyObjNum].SetActive(true);
                    _foreachKeyObjNum++;
                }
                _foreachKeyObjNum = 0;

                sucub.sequencesRandomFiller(numberOfLatters);
                importantKeysManager.CheckForSameLatters();
                if (importantKeysManager.isSameLatterFound == false) _sucubFirstLatterChange = true;
            }

            if (sucub.sequences[_sucubSequenceNumber])
            {
                keys[_sucubSequenceNumber].SetActive(false);
                _sucubSequenceNumber++;
            }

            if (sucub.isEverySequencesTrue)
            {
                _sucubFirstLatterChange = false;
                _sucubSequenceNumber = 0;
                isPlayerDodged = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            _twoInOne--;
            if (_twoInOne == 0)
            {
                foreach (var key in keys)
                {
                    keys[_foreachKeyObjNum].SetActive(false);
                    _foreachKeyObjNum++;
                }
                _foreachKeyObjNum = 0;
                sucubRavager();
                _sucubFirstLatterChange = false;
            }
        }
    }

    void Update()
    {
        if (isPlayerDodged && !hitTrigger._isCustomerTooClose)
        {
            if (dodgeResetTimer > 0) dodgeResetTimer -= Time.deltaTime;
            else
            {
                isPlayerDodged = false;
                dodgeResetTimer = dodgeResetTimerStart;
            }
        }

        //if (!_sucubFirstLatterChange) //Рандомно заполнить в начале игры. В методе Start отказывается работать >:(
        //{
        //    sucub.sequencesRandomFiller(numberOfLatters);
        //    importantKeysManager.CheckForSameLatters();
        //    if (importantKeysManager.isSameLatterFound == false) _sucubFirstLatterChange = true;
        //}

        //if(Vector2.Distance(player.transform.position, transform.position) < 8)
        //{
        //    if(!_sucubFirstLatterChange)
        //    {
        //        foreach (var keyObject in keys)
        //        {
        //            keys[_foreachKeyObjNum].SetActive(true);
        //            _foreachKeyObjNum++;
        //        }
        //        _foreachKeyObjNum = 0;

        //        sucub.sequencesRandomFiller(numberOfLatters);
        //        importantKeysManager.CheckForSameLatters();
        //        if (importantKeysManager.isSameLatterFound == false) _sucubFirstLatterChange = true;
        //    }

        //    if (sucub.sequences[_sucubSequenceNumber])
        //    {
        //        keys[_sucubSequenceNumber].SetActive(false);
        //        _sucubSequenceNumber++;
        //    }

        //    if (sucub.isEverySequencesTrue)
        //    {

        //    }
        //}
    }

    private void sucubRavager()
    {
        foreach (bool i in sucub.sequences)
        {
            sucub.sequences[_sucubRevagerForeachNum] = false;
            _sucubRevagerForeachNum++;
        }
        _sucubRevagerForeachNum = 0;
        sucub.isEverySequencesTrue = false;
        sucub.latterNumber = 0;
    }
}
