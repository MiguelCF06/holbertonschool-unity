using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("InvertY"))
        {
            this.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("InvertY") == 0 ? false : true;
        }
        else
        {
            this.GetComponentInChildren<Toggle>().isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("InvertY", this.GetComponentInChildren<Toggle>().isOn ? 1 : 0);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
