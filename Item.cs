using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int countdownTime = 6;
    public GameObject timekeeper;
    public GameObject CTRL_Player;
    //ใอ้ไข่
    public void item1()
    {

    }

    //ไก่
    public void item2()
    {
        CTRL_Player.GetComponent<CTRL_Player>().speed += 1.5f;
        StartCoroutine(startitem2());
    }
    IEnumerator startitem2()
    {
        while(countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        CTRL_Player.GetComponent<CTRL_Player>().speed -= 1.5f;
    }

    //ประทัด
    public void item3()
    {
        timekeeper.GetComponent<TimeLefts>().gameTime += 20f;
    }
}
