using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestination : MonoBehaviour
{
    public GameObject Destination;
    void Start()
    {
        
    }

    void Update()
    {
        checkDestination();
    }

    void checkDestination()
    {
        if (Destination != transform.GetChild(0).gameObject)
        {
            Debug.Log("Have");
        }
        else
        {
            Debug.Log("Not Have");
        }
    }
}
