using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wather : MonoBehaviour
{

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i <= FindObjectOfType<LifeCount>().livesRemaining; i++)
            {
                FindObjectOfType<LifeCount>().LoseLife();
            }

        }
    }
}
