using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
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
            FindObjectOfType<BirdController>().MoveToNextPoint();
            anim.SetBool("InCage", fly);

        }
    }
}
