using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
      [SerializeField] AudioMixerSnapshot paused;
      [SerializeField] AudioMixerSnapshot unpaused;
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
            paused.TransitionTo(.01f);
      }

      public void Resume()
      {
            Cursor.lockState = CursorLockMode.Locked;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            unpaused.TransitionTo(.01f);
      }

      public void Restart()
      {
            time.time = 0.0f;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            unpaused.TransitionTo(.01f);
      }

      public void MainMenu()
      {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            unpaused.TransitionTo(.01f);
      }

      public void Options()
      {
          Time.timeScale = 1f;
          PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
          SceneManager.LoadScene("Options");
          unpaused.TransitionTo(.01f);
      }
}
