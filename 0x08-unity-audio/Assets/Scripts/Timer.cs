using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text finalTimeText;
    public Text timerText;
    public float time = 0.0f;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (finish)
            return;

        time += Time.deltaTime;

        string minutes = ((int) time / 60).ToString();
        string seconds = (time % 60).ToString("00.00");

        timerText.text = minutes + ":" + seconds;
    }

    public void Win()
    {
        finish = true;
        finalTimeText.text = timerText.text;
        timerText.enabled = false;
    }

    public void WinTimer()
    {
        finish = true;
        timerText.color = Color.green;
        timerText.fontSize = 60;
    }
}
