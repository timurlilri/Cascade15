using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FrCounter.Fruit += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (FindObjectOfType<HeroMove>().isDead == true)
        {
            FrCounter.Fruit = 0;
        }

    }
}
