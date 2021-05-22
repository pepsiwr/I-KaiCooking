using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class badfood : MonoBehaviour
{
    public Slider CookingBar;
    //public GameObject goodfood;


    void Start()
    {
        StartCoroutine(Badfood());
    }

    IEnumerator Badfood()
    {
        
        yield return new WaitForSeconds(0.1f);
        this.gameObject.transform.GetComponent<Change>().CookingBar = CookingBar;

        CookingBar.gameObject.SetActive(false);
    }
}
