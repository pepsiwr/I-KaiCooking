using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMatupayad : MonoBehaviour
{
    public Slider CookingBar;
    public float cookingtime;
    private float timegkeeper = 0.0f;
    public GameObject kanom4;
    public GameObject Fire;
    public GameObject smoke;

    void Start()
    {
        StartCoroutine(StartCookingBar());
        CookingBar.maxValue = cookingtime;
        CookingBar.value = 0.0f;
        CookingBar.gameObject.SetActive(true);

    }

    IEnumerator StartCookingBar()
    {
        while (timegkeeper < cookingtime)
        {
            yield return new WaitForSeconds(0.1f);
            timegkeeper += 0.1f;
            CookingBar.value = timegkeeper;
            yield return null;
        }
        //badfood
        if (CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color == new Color(233f / 255f, 79f / 255f, 55f / 255f))
        {
            CookingBar.gameObject.SetActive(false);
            Fire.gameObject.SetActive(false);
            smoke.gameObject.SetActive(true);
            Destroy(gameObject);
            GameObject k4 = Instantiate(kanom4, transform.position, Quaternion.identity) as GameObject;
            k4.transform.GetComponent<BadfoodBar>().CookingBar = CookingBar;
            k4.transform.GetComponent<BadfoodBar>().Fire = Fire;
            k4.transform.GetComponent<BadfoodBar>().smoke = smoke;
        }
        //goodfood
        else
        {
            Destroy(gameObject);
            GameObject k4 = Instantiate(kanom4, transform.position, Quaternion.identity) as GameObject;
            k4.transform.GetComponent<StartMatupayad>().CookingBar = CookingBar;
            k4.transform.GetComponent<StartMatupayad>().Fire = Fire;
            k4.transform.GetComponent<StartMatupayad>().smoke = smoke;
            smoke.gameObject.SetActive(true);

            //เปลี่ยนสีSlider ในขั้นตอนที่2 //สีแดง
            Color color = new Color(233f / 255f, 79f / 255f, 55f / 255f);
            CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
        }
    }
}
