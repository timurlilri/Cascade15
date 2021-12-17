using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1 : MonoBehaviour
{
    public bool fly;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            FindObjectOfType<Bird1Controller>().MoveToNextPoint();
            anim.SetBool("InCage", fly);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Bird1Controller>().MoveToPoint();
        }
    }
}
