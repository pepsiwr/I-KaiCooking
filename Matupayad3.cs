using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matupayad3 : MonoBehaviour
{
    public GameObject kanom3;
    public Slider CookingBar;
    public GameObject Fire;
    public GameObject smoke;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tua")
        {
            CookingBar.gameObject.SetActive(true);

            StartCoroutine(changfood());
            //ทำลย Object ที่มาชน
            Destroy(collision.gameObject);
        }
        /*else
        {
            CookingBar.gameObject.SetActive(false);
        }*/
    }
    IEnumerator changfood()
    {
        yield return new WaitForSeconds(0.1f); //คำสั่งหน่วงเวลา

        gameObject.SetActive(false);

        //สร้างObject ใหม่
        GameObject k3 = Instantiate(kanom3, transform.position, Quaternion.identity) as GameObject;
        k3.transform.GetComponent<StartMatupayad>().CookingBar = CookingBar;
        k3.transform.GetComponent<StartMatupayad>().Fire = Fire;
        k3.transform.GetComponent<StartMatupayad>().smoke = smoke;
        CookingBar.gameObject.SetActive(false);
        Fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(true);
    }
}
