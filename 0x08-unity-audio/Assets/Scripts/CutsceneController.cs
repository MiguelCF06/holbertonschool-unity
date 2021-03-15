using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] GameObject player, mainCamera, timerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z == -6.25)
        {
            player.GetComponent<PlayerController>().enabled = true;
            mainCamera.SetActive(true);
            timerCanvas.SetActive(true);
            this.gameObject.SetActive(false);
        }   
    }
}
