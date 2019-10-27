using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused;

    private bool isDisplayed;

    public void OpenScene(int scene)
    {
        SceneManager.LoadScene(scene);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame(GameObject screen)
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            screen.SetActive(false);
        }
        else
        {
            screen.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void DisplayScreen(GameObject screen)
    {
        if (isDisplayed)
        {
            screen.SetActive(false);
            isDisplayed = false;
        }
        else
        {
            screen.SetActive(true);
            isDisplayed = true;
        }
    }
}