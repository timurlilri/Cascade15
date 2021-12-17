using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public Animator anim;

    public void LoseLife()
    {
        livesRemaining--;// Decrease the value of livesRemaining
        lives[livesRemaining].enabled = false; // Hide one of the life images
        if (livesRemaining <= 0)  // If we run out of lives we lose the game
        {
            FindObjectOfType<HeroMove>().Die();
        }
    }
    public void LoseAllLifes()
    {
            FindObjectOfType<HeroMove>().Die();
    }
    public void BonusLife()
    {
        if (livesRemaining < 5)
        {
            lives[livesRemaining].enabled = true;
            livesRemaining++;

        }
        else if (livesRemaining >= 5)
        {
            livesRemaining = livesRemaining;
        }
        
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }
}
