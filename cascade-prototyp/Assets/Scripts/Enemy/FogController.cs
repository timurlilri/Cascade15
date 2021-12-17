using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Wait();
            if (FindObjectOfType<MaskController>().WasFirstTimeReleased == false)
            {
                FindObjectOfType<LifeCount>().LoseLife();
            }

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }

}
