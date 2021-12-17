using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button level01Button, level02Button, level03Button;
    int levelPassed;

    void Start() //crutch method, but it works
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level01Button.interactable = true;
        level02Button.interactable = false;
        level03Button.interactable = false;

        switch(levelPassed){
            case 1:
                level01Button.interactable = true;
                level02Button.interactable = true;
                break;
            case 2:
                level01Button.interactable = true;
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
        }
    }

    public void LevelToLoad (int level)
    {
        SceneManager.LoadScene(2);
    }

    public void resetPlayerPrefs()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
