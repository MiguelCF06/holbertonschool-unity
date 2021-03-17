using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseVolumeManager : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot paused;
    [SerializeField] AudioMixerSnapshot unpaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        Lowpass();
    }

    void Lowpass()
      {
          if (Time.timeScale == 0)
          {
              paused.TransitionTo(.01f);
          }
          else
          {
              unpaused.TransitionTo(.01f);
          }
      }
}
