using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snike : MonoBehaviour
{
    public bool walk;
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
            FindObjectOfType<SnikeController>().MoveToNextPoint();
            anim.SetBool("InCage", walk);
        }
    }
    private void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
