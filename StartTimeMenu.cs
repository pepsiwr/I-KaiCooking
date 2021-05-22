using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimeMenu : MonoBehaviour
{
    public Slider MenuBar;
    public float MenuTime;
    private float timekeeper = 0.0f;
    public SentFood sf;
    void Start()
    {
        sf = GameObject.Find("SentFood").GetComponent<SentFood>();

        StartCoroutine(StartMenu());
        MenuBar.maxValue = MenuTime;
        MenuBar.value = 0.0f;
    }

    IEnumerator StartMenu()
    {
        while(timekeeper<MenuTime)
        {
            timekeeper += 1.0f * Time.deltaTime;
            MenuBar.value = timekeeper;

            if (MenuBar.value >= 25 && MenuBar.value <=45)
            {
                Color yellow = new Color(50f, 255f, 55f/255f);
                MenuBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = yellow;
            }
            else if(MenuBar.value > 45)
            {
                Color red = new Color(233f/255f, 80f/255f, 55f / 255f);
                MenuBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = red;
            }
            yield return null;
        }

        for (int i = 0; i < sf.menus.Length; i++)
        {
            if (GameObject.ReferenceEquals(this.gameObject.transform.parent.gameObject, sf.menus[i].ui.gameObject))
            {
                StartCoroutine(sf.CreateUI(i));
            }
        }


    }
}
