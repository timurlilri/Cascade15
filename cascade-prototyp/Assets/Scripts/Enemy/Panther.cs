using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panther : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;

    public float speed;
    public float agroDistance;
    public Animator anim;

    bool eating = false;
    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        anim.SetBool("Hunt", false);
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroDistance && eating == false)
        {
            StartHunting();
        }   
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
        anim.SetBool("Hunt", true);
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
        }
        if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
        }

    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            FindObjectOfType<LifeCount>().LoseLife();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            eating = true;
        }
    }
}
