using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    public static FinishManager instance = null;
    int sceneIndex, levelPassed;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            UnLockLevel();
            SceneManager.LoadScene(1);
        }
    }
    public void UnLockLevel()
    {
        if (sceneIndex == 3)
            SceneManager.LoadScene(1);
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        }

    }
}
