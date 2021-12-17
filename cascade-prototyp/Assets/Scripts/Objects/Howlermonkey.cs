using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howlermonkey : MonoBehaviour
{
    public bool go;
    public Animator anim;
    public byte counter = 0;
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
            counter++;
            if (counter == 2)
            {
                FindObjectOfType<MonkezController>().MoveToNextPoint();
                anim.SetBool("InCage", go);
            }
        }
    }
}
