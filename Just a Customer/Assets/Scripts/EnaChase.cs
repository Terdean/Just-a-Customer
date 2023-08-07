using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnaChase: MonoBehaviour
{
    public Animator Painter;
    public float speed = 5f;
    public Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) <3.5) 
        {
            Painter.SetBool("AnChange", true);
        }
        else 
        {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 
        }
        if (player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
