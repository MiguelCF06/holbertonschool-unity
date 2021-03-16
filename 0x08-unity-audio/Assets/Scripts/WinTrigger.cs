using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victoryClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            audioSource.Stop();
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            other.GetComponent<Timer>().Win();
            audioSource.PlayOneShot(victoryClip);
        }
    }
}
