using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeLefts : MonoBehaviour
{
    public Text timeText;
    public float gameTime;
    public GameObject gameover = null;
    public GameObject player;

    public bool stopTimer;
    private float timestamp;
    public float time;

    void Start()
    {
        stopTimer = false;
        timestamp = Time.time;
    }

    void Update()
    {
        //float time = gameTime - Time.time;
        time = gameTime - Time.time + timestamp;

        int minutes = Mathf.FloorToInt(time / 60f);
        int second = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, second);

        if(time<=0)
        {
            stopTimer = true;
            gameover.SetActive(true);
            player.GetComponent<CTRL_Player>().enabled = false;
        }

        if(stopTimer == false)
        {
            timeText.text = textTime;
        }
        
    }
}
