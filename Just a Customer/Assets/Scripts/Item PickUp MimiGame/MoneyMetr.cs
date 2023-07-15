using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMetr : MonoBehaviour
{
    public int amountOfMoney;
    public GameObject moneyOriginalObj;
    public GameObject[] allMoneyObjects;
    public GameObject posOnInterface;
    private Vector3 finalPos;
    private Quaternion finalRot;

    private int foreachNum;
    private bool starterMoneyGived = false;

    private void Start()
    {
        Array.Resize(ref allMoneyObjects, amountOfMoney);
        foreach (GameObject i in allMoneyObjects)
        {
            randomPosInPile();

            allMoneyObjects[foreachNum] = moneyOriginalObj;
            Instantiate(allMoneyObjects[foreachNum], finalPos, finalRot);
            GameObject.Find("moneyOriginalObj(Clone)").name = "moneyOriginalObj(Clone)" + foreachNum;
            foreachNum++;
        }
        foreachNum = 0;
        starterMoneyGived = true;
    }

    void Update()
    {
        if(starterMoneyGived)
        {
            if (amountOfMoney != allMoneyObjects.Length)
            {
                int helpNum = allMoneyObjects.Length - 1;
                if (amountOfMoney < allMoneyObjects.Length)
                {
                    Destroy(GameObject.Find("moneyOriginalObj(Clone)" + helpNum));
                    Array.Resize(ref allMoneyObjects, allMoneyObjects.Length - 1);
                }
                else if (amountOfMoney > allMoneyObjects.Length)
                {
                    Array.Resize(ref allMoneyObjects, allMoneyObjects.Length + 1);
                    allMoneyObjects[allMoneyObjects.Length - 1] = moneyOriginalObj;
                    randomPosInPile();
                    Instantiate(allMoneyObjects[allMoneyObjects.Length - 1], finalPos, finalRot);
                    GameObject.Find("moneyOriginalObj(Clone)").name = "moneyOriginalObj(Clone)" + helpNum;
                }
            }
        }
    }

    private void randomPosInPile()
    {
        finalPos.x = posOnInterface.transform.position.x + UnityEngine.Random.Range(-1f, 2f);
        finalPos.y = posOnInterface.transform.position.y + UnityEngine.Random.Range(-1f, 2f);
        finalRot.z = posOnInterface.transform.rotation.z + UnityEngine.Random.Range(-360f, 360f);
    }
}
