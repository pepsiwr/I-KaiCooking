using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageStick : MonoBehaviour
{
    public Image obj;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        obj.transform.position = pos;

    }
}
