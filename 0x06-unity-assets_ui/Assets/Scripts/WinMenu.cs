using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        int number;

        number = Int32.Parse(SceneManager.GetActiveScene().name.Substring(5));
        if (number < 3)
            SceneManager.LoadScene(String.Format("Level{0:D2}", number + 1));
        else
            SceneManager.LoadScene("MainMenu");
    }
}
