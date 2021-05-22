using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCooking : MonoBehaviour
{
    public Slider CookingBar;
    public float cookingtime;
    private float timegkeeper = 0.0f;
    public GameObject kanomB;
    public GameObject Fire;
    public GameObject smoke;

    void Start()
    {
        StartCoroutine(StartCookingBar());
        CookingBar.maxValue = cookingtime;
        CookingBar.value = 0.0f;
        
    }

    IEnumerator StartCookingBar()
    {
        //float timeMax = cookingtime;

        while (timegkeeper < cookingtime)
        {
            yield return new WaitForSeconds(0.1f);
            timegkeeper += 0.1f;
            CookingBar.value = timegkeeper;
            yield return null;
            
        }

        //badfood
        if(CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color == new Color(233f / 255f, 79f / 255f, 55f / 255f))
        {
            CookingBar.gameObject.SetActive(false);
            Fire.gameObject.SetActive(false);
            smoke.gameObject.SetActive(true);
            Destroy(gameObject);
            GameObject kb = Instantiate(kanomB, transform.position, Quaternion.identity) as GameObject;
            kb.transform.GetComponent<BadfoodBar>().CookingBar = CookingBar;
            kb.transform.GetComponent<BadfoodBar>().Fire = Fire;
            kb.transform.GetComponent<BadfoodBar>().smoke = smoke;
        }
        //goodfood
        else
        {
            Destroy(gameObject);
            GameObject kb = Instantiate(kanomB, transform.position, Quaternion.identity) as GameObject;
            kb.transform.GetComponent<StartCooking>().CookingBar = CookingBar;
            kb.transform.GetComponent<StartCooking>().Fire = Fire;
            kb.transform.GetComponent<StartCooking>().smoke = smoke;
            Fire.gameObject.SetActive(true);
            smoke.gameObject.SetActive(true);

            //เปลี่ยนสีSlider ในขั้นตอนที่2 //สีแดง
            Color color = new Color(233f / 255f, 79f / 255f, 55f / 255f);
            CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
        }

        


    }
}
