using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delfin : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<NewPlatform>().MoveToPoint();
        }
    }
}
