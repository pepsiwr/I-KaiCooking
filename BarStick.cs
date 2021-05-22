using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarStick : MonoBehaviour
{
    public Slider Cookingbar;
    void Start()
    {
       // StartCoroutine(barstick());
    }

    /*IEnumerator barstick()
    {
        yield return null;
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        Cookingbar.transform.position = pos;
    }*/
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        Cookingbar.transform.position = pos;

    }
}
