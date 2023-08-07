using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitByCustomersTrigger : MonoBehaviour
{
    public float damageOfHit;
    public CustomerAttack dodge;
    private health playersHP;
    
    [HideInInspector]
    public bool _isCustomerTooClose;
    private int _twoInOne;

    void Start()
    {
        playersHP = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Customer")
        {
            _twoInOne++;
            _isCustomerTooClose = true;
            if (!dodge.isPlayerDodged)
            {
                playersHP.hp_minus(damageOfHit);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            _twoInOne--;
            if(_twoInOne == 0)
            {
                _isCustomerTooClose = false;
            }
        }
    }
}