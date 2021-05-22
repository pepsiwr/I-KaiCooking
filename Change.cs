using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public GameObject kanomA;
    public Slider CookingBar;
    public GameObject Fire;
    public GameObject smoke;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sob")
        {
            CookingBar.gameObject.SetActive(true);
            Fire.gameObject.SetActive(false);
            smoke.gameObject.SetActive(false);
            StartCoroutine(changfood());
            //ทำลย Object ที่มาชน
            Destroy(collision.gameObject);
        }
        else
        {
            CookingBar.gameObject.SetActive(false);
        }
    }
    IEnumerator changfood()
    {
        yield return new WaitForSeconds(0.1f); //คำสั่งหน่วงเวลา
        gameObject.SetActive(false);
       
        //สร้างObject ใหม่
        GameObject ka = Instantiate(kanomA, transform.position, Quaternion.identity) as GameObject;
        ka.transform.GetComponent<StartCooking>().CookingBar = CookingBar;
        ka.transform.GetComponent<StartCooking>().Fire = Fire;
        ka.transform.GetComponent<StartCooking>().smoke = smoke;
        Fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(true);
        //ka.transform.GetComponent<StartCooking>().kata = this.gameObject;
    }
}
