using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangMatapayad : MonoBehaviour
{
    public GameObject kanom1;
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
        GameObject k1 = Instantiate(kanom1, transform.position, Quaternion.identity) as GameObject;
        k1.transform.GetComponent<Matapayad2>().CookingBar = CookingBar;
        k1.transform.GetComponent<Matapayad2>().Fire = Fire;
        k1.transform.GetComponent<Matapayad2>().smoke = smoke;
        CookingBar.gameObject.SetActive(false);
        Fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(true);
    }
}
