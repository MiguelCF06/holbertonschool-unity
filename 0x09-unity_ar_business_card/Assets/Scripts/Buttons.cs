using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buttons : MonoBehaviour
{
    public string url;
    AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void OpenTheUrl()
    {
        audioSource.PlayOneShot(clickSound);
        Application.OpenURL(url);
    }
}
