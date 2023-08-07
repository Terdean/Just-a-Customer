using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatience : MonoBehaviour
{
    public Animator Painter;
    public health HelPont;
    public float speed;
    public GameObject[] dot;
    private int RndmRun;
    private float Timer;
    public float TStrt;
    void Start()
    {
        RndmRun = Random.Range(0, dot.Length);
    }
    void Update()
    {
        Painter.SetFloat("SUS?", HelPont.hp_schet);
        if (dot[RndmRun].transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (dot[RndmRun].transform.position.x < transform.position.x) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Timer > 0) Timer -= Time.deltaTime;
        else
        {
            RndmRun = Random.Range(0, dot.Length);
            Timer = TStrt;
        }
        transform.position = Vector3.MoveTowards(transform.position, dot[RndmRun].transform.position, speed*Time.deltaTime);
    }
}
