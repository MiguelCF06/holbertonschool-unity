using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finish)
            return;

        float time = Time.time;

        string minutes = ((int) time / 60).ToString();
        string seconds = (time % 60).ToString("00.00");

        timerText.text = minutes + ":" + seconds;
    }

    public void WinTimer()
    {
        finish = true;
        timerText.color = Color.green;
        timerText.fontSize = 60;
    }
}
