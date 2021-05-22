using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCheck : MonoBehaviour
{
    public GameObject obj;
    public GameObject goodfood;
    public GameObject badfood;
    public GameObject Plate;
    public GameObject goodMatupayad;
    public GameObject badMatupayad;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Milk" || other.gameObject.tag == "Sob" || other.gameObject.tag == "Tua"|| other.gameObject.tag == "Plate" || other.gameObject.tag == "Food" || other.gameObject.tag == "goodfood" || other.gameObject.tag == "badfood"|| other.gameObject.tag == "MenuNK" || other.gameObject.tag == "MenuMatupayad")
        {
            obj = other.gameObject;
        }
        if(other.gameObject.tag == "GoodFood")
        {
            goodfood = other.gameObject;
            
        }
        if (other.gameObject.tag == "BadFood")
        {
            badfood = other.gameObject;

        }
        if (other.gameObject.tag == "Plate")
        {
            Plate = other.gameObject;

        }
        if (other.gameObject.tag == "goodMatupayad")
        {
            goodMatupayad = other.gameObject;

        }
        if (other.gameObject.tag == "badMatupayad")
        {
            badMatupayad = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        obj = null;
        goodfood = null;
        badfood = null;
        Plate = null;
        goodMatupayad = null;
        badMatupayad = null;

    }
}
