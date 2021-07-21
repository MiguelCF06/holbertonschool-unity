using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

    public void PreviousScene()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }
}
