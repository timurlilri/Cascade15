using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BonusCounter.Bonus += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (FindObjectOfType<HeroMove>().isDead == true)
        {
            BonusCounter.Bonus = 0;
        }

    }
}
