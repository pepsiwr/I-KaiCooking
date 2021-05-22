using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matapayad2 : MonoBehaviour
{
    public GameObject kanom2;
    public Slider CookingBar;
    public GameObject Fire;
    public GameObject smoke;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Milk")
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
        GameObject k2 = Instantiate(kanom2, transform.position, Quaternion.identity) as GameObject;
        k2.transform.GetComponent<Matupayad3>().CookingBar = CookingBar;
        k2.transform.GetComponent<Matupayad3>().Fire = Fire;
        k2.transform.GetComponent<Matupayad3>().smoke = smoke;
        CookingBar.gameObject.SetActive(false);
        Fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(true);
    }
}
