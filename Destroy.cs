using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bin")
        {
            StartCoroutine(DestroytDelay());
        }
    }
    IEnumerator DestroytDelay()
    {
        yield return new WaitForSeconds(1.0f); //คำสั่งหน่วงเวลา

        Destroy(gameObject);
    }
}
