using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentFood : MonoBehaviour
{
    public class Menu
    {
        public Transform pos;
        public GameObject ui;
        public string name;
    }

    public Menu[] menus = new Menu[2];

    public Text CoinText;
    public Text Score;
    public GameObject Ui_1;
    public GameObject Ui_2;
    public GameObject gameover = null;
    public GameObject timeStop;
    public GameObject starParticle;
    public Transform A;
    public Transform B;
    public Transform mCanvas;
    int randomInt;
    GameObject current;
    public List<GameObject> sp = new List<GameObject>();
    //public List<GameObject> menu = new List<GameObject>();


    private void Start()
    {
        menus[0] = new Menu();
        menus[0].pos = A;
        menus[0].ui = Instantiate(Ui_1, A.position, Quaternion.identity);
        menus[0].ui.transform.SetParent(mCanvas);
        menus[0].name = menus[0].ui.name;

        menus[1] = new Menu();
        menus[1].pos = B;
        menus[1].ui = Instantiate(Ui_2, B.position, Quaternion.identity);
        menus[1].ui.transform.SetParent(mCanvas);
        menus[1].name = menus[1].ui.name;

    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < 2; i++)
        {
            if (collision.gameObject.tag == menus[i].name.Split("("[0])[0])
            {
                StartCoroutine(CreateUI(i));
                Destroy(collision.gameObject);

                PointData.Coin += 10; //PointData คือscriptที่เก็บค่าcoinไว้แล้ว
                CoinText.text = PointData.Coin.ToString();
                Score.text = PointData.Coin.ToString();

                starParticle.SetActive(true);
                StartCoroutine(stopParticle());
                
            }
        }
        //starParticle.SetActive(false);
    }

    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(1.0f);
        starParticle.SetActive(false);
    }

    public IEnumerator CreateUI(int i)
    {
        yield return new WaitForSeconds(0.1f);
        
        if (i == 0)
        {
            Destroy(menus[0].ui);

            //เลื่อนตำแหน่งของ[1] ไปที่[0]
            menus[0].ui = menus[1].ui;
            menus[0].ui.transform.position = menus[0].pos.position;
            menus[0].name = menus[1].name;
        }
        else
        {
            Destroy(menus[1].ui);
            //starParticle.SetActive(false);
        }

        //สร้างUi มาในตำแหน่ง[1]
        menus[1].ui = SpawnRandom();
        if (menus[1].ui)
        {
            menus[1].ui.transform.position = menus[1].pos.position;
            menus[1].name = menus[1].ui.name;
        }

        //ถ้าไม่มีUI[0] ให้จบเกมทันทีและหยุดเวลา
        if (menus[0].ui == null)
        {
            gameover.gameObject.SetActive(true);
            timeStop.GetComponent<TimeLefts>().stopTimer = true;
        }
    }
    GameObject SpawnRandom()
    {
        if (sp.Count > 0)
        {
            randomInt = Random.Range(0, sp.Count);
            GameObject g = Instantiate(sp[randomInt], B.position, B.rotation);
            g.transform.SetParent(mCanvas);
            current = sp[randomInt];
            sp.Remove(current);
            return g;
        }
        else
        {
            return null;
        }
    }

    IEnumerator nomkrok()
    {
        yield return new WaitForSeconds(0.1f);

        PointData.Coin += 10; //PointData คือscriptที่เก็บค่าcoinไว้แล้ว
        CoinText.text = PointData.Coin.ToString();
        Score.text = PointData.Coin.ToString();
    }
    IEnumerator matupayad()
    {
        yield return new WaitForSeconds(0.1f);

        PointData.Coin += 10; //PointData คือscriptที่เก็บค่าcoinไว้แล้ว
        CoinText.text = PointData.Coin.ToString();
    }
}
