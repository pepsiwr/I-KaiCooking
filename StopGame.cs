using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

public class StopGame : MonoBehaviour
{
    public GameObject stop;
    public GameObject stopTime;
    //public GameObject postposess;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stop.gameObject.SetActive(true);
            stopTime.GetComponent<TimeLefts>().stopTimer = true;
            //postposess.GetComponent<DepthOfField>().focalLength.value = 300;
        }
    }

    public void play()
    {
        stop.gameObject.SetActive(false);
        stopTime.GetComponent<TimeLefts>().stopTimer = false;
        //postposess.GetComponent<DepthOfField>().focalLength.value = 1;
    }
    
}
