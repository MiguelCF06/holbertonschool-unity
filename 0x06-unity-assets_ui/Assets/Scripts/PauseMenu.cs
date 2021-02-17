using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
      [SerializeField] GameObject pauseCanvas;
      [SerializeField] Timer time;
      bool isPaused;

      void Update()
      {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
      }

      public void Pause()
      {
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
      }

      public void Resume()
      {
          Cursor.lockState = CursorLockMode.Locked;
          pauseCanvas.SetActive(false);
          Time.timeScale = 1f;
          isPaused = false;
      }

      public void Restart()
      {
          time.time = 0.0f;
          Time.timeScale = 1f;
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

      public void MainMenu()
      {
          Time.timeScale = 1f;
          SceneManager.LoadScene("MainMenu");
      }

      public void Options()
      {
          Time.timeScale = 1f;
          PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
          SceneManager.LoadScene("Options");
      }
}
