using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public bool maskOn = false;
    public Animator anim;
    public bool WasFirstTimeReleased = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MaskOn();
    }

    public void MaskOn()
    {
        if (maskOn && Input.GetKeyDown(KeyCode.M))
        {
            if (WasFirstTimeReleased)
            {
                anim.SetBool("MaskON", false);
                WasFirstTimeReleased = false;
            }
            else
            {
                anim.SetBool("MaskON", true);
                WasFirstTimeReleased = true;
            }
        }
        

    }


}
