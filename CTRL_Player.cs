using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTRL_Player : MonoBehaviour
{
    public GameObject hand;
    public GameObject goodfood;
    public GameObject badfood;
    public GameObject goodMatupayad;
    public GameObject badMatupayad;
    public GameObject kataNK;
    public GameObject kataMatupayad;

    //public GameObject NPC;

    //public Transform spawnNPC;

    public float speed = 10.0f;
    public float gravity = 8.0f;
    public float rotationSpeed = 0f;

    CharacterController controller;
    Rigidbody rb;
    Vector3 moveDir = Vector3.zero;
    Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //anim.enabled = false;
        //anim.enabled = true;
        //anim.applyRootMotion = true;
        //Instantiate(NPC, spawnNPC.position, Quaternion.identity);

    }
    void Update()
    {
        //pick item
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Pick", true);
            //anim.SetInteger("Condition", 2);
            //anim.SetBool("Pick", true);
            if (hand.transform.GetComponent<HandCheck>().obj != null)
            {
                GameObject obj = hand.transform.GetComponent<HandCheck>().obj;
                obj.transform.position = hand.transform.position;
                obj.transform.parent = hand.transform; //ให้ตามตำแหน่ง
                obj.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (hand.transform.GetComponent<HandCheck>().Plate != null)
            {
                //Nomkrok
                if (hand.transform.GetComponent<HandCheck>().goodfood != null)
                {
                    GameObject food;
                    food = Instantiate(goodfood, transform.GetChild(0).transform.position, Quaternion.identity); //จานที่มีอาหาร
                    food.transform.position = hand.transform.position; //ให้ย้ายไปตำแหน่งของมือ
                    food.transform.parent = hand.transform; //ให้ตามตำแหน่ง
                    food.GetComponent<Rigidbody>().isKinematic = true;

                    //ทำลายจานที่อยู่ในมือ
                    Destroy(hand.transform.GetChild(0).gameObject);
                    
                    Vector3 katapos = hand.GetComponent<HandCheck>().goodfood.gameObject.transform.position; //เก็บตำแหน่งของกระทะไว้ที่ katapos

                    //ปิด Slider
                    hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().CookingBar.gameObject.SetActive(false);
                    //ปิดFire
                    hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().Fire.gameObject.SetActive(false);
                    //ปิดSmoke
                    hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().smoke.gameObject.SetActive(false);

                    //ทำลายกระทะขนมครก
                    Destroy(hand.GetComponent<HandCheck>().goodfood);

                    //สร้างกระทะขึ้นมาใหม่
                    GameObject nk = Instantiate(kataNK, katapos, Quaternion.identity);
                    nk.GetComponent<Change>().CookingBar = hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().CookingBar;
                    //ใส่Fire ใน nk
                    nk.GetComponent<Change>().Fire = hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().Fire;
                    //ใส่Smoke ใน nk
                    nk.GetComponent<Change>().smoke = hand.GetComponent<HandCheck>().goodfood.gameObject.GetComponent<StartCooking>().smoke;

                    //เปลี่ยนเป็นสีเขียว
                    Color color = new Color(55f / 255f, 233f / 255f, 55f / 255f);
                    nk.GetComponent<Change>().CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;

                }
                if (hand.transform.GetComponent<HandCheck>().badfood != null)
                {
                    GameObject food;
                    food = Instantiate(badfood, transform.GetChild(0).transform.position, Quaternion.identity);
                    food.transform.position = hand.transform.position; //ให้ย้ายไปตำแหน่งของมือ
                    food.transform.parent = hand.transform; //ให้ตามตำแหน่ง
                    food.GetComponent<Rigidbody>().isKinematic = true;
                    //ทำลายจานที่อยู่ในมือ
                    Destroy(hand.transform.GetChild(0).gameObject);

                    Vector3 katapos = hand.GetComponent<HandCheck>().badfood.gameObject.transform.position; //เก็บตำแหน่งของกระทะไว้ที่ katapos
                    //ปิดSmoke
                    hand.GetComponent<HandCheck>().badfood.gameObject.GetComponent<BadfoodBar>().smoke.gameObject.SetActive(false);
                    //ทำลายกระทะขนมครก
                    Destroy(hand.GetComponent<HandCheck>().badfood);

                    //สร้างกระทะขึ้นมาใหม่
                    GameObject nk = Instantiate(kataNK, katapos, Quaternion.identity);
                    nk.GetComponent<Change>().CookingBar = hand.GetComponent<HandCheck>().badfood.gameObject.GetComponent<BadfoodBar>().CookingBar;
                    //ใส่Fire ใน nk
                    nk.GetComponent<Change>().Fire = hand.GetComponent<HandCheck>().badfood.gameObject.GetComponent<BadfoodBar>().Fire;
                    //ใส่Smoke ใน nk
                    nk.GetComponent<Change>().smoke = hand.GetComponent<HandCheck>().badfood.gameObject.GetComponent<BadfoodBar>().smoke;

                    //เปลี่ยนเป็นสีเขียว
                    Color color = new Color(55f / 255f, 233f / 255f, 55f / 255f);
                    nk.GetComponent<Change>().CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
                }

                //Matupayad
                if (hand.transform.GetComponent<HandCheck>().goodMatupayad != null)
                {
                    GameObject food;
                    food = Instantiate(goodMatupayad, transform.GetChild(0).transform.position, Quaternion.identity); //จานที่มีอาหาร
                    food.transform.position = hand.transform.position; //ให้ย้ายไปตำแหน่งของมือ
                    food.transform.parent = hand.transform; //ให้ตามตำแหน่ง
                    food.GetComponent<Rigidbody>().isKinematic = true;

                    //ทำลายจานที่อยู่ในมือ
                    Destroy(hand.transform.GetChild(0).gameObject);

                    Vector3 katapos = hand.GetComponent<HandCheck>().goodMatupayad.gameObject.transform.position; //เก็บตำแหน่งของกระทะไว้ที่ katapos

                    //ปิด Slider
                    hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().CookingBar.gameObject.SetActive(false);
                    //ปิดFire
                    hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().Fire.gameObject.SetActive(false);
                    //ปิดSmoke
                    hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().smoke.gameObject.SetActive(false);

                    //ทำลายกระทะขนมครก
                    Destroy(hand.GetComponent<HandCheck>().goodMatupayad);

                    //สร้างกระทะขึ้นมาใหม่
                    GameObject mt = Instantiate(kataMatupayad, katapos, Quaternion.identity);
                    mt.GetComponent<ChangMatapayad>().CookingBar = hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().CookingBar;
                    //ใส่Fire ใน mt
                    mt.GetComponent<ChangMatapayad>().Fire = hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().Fire;
                    //ใส่Smoke ใน mt
                    mt.GetComponent<ChangMatapayad>().smoke = hand.GetComponent<HandCheck>().goodMatupayad.gameObject.GetComponent<StartMatupayad>().smoke;

                    //เปลี่ยนเป็นสีเขียว
                    Color color = new Color(55f / 255f, 233f / 255f, 55f / 255f);
                    mt.GetComponent<ChangMatapayad>().CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;

                }
                if (hand.transform.GetComponent<HandCheck>().badMatupayad != null)
                {
                    GameObject food;
                    food = Instantiate(badMatupayad, transform.GetChild(0).transform.position, Quaternion.identity);
                    food.transform.position = hand.transform.position; //ให้ย้ายไปตำแหน่งของมือ
                    food.transform.parent = hand.transform; //ให้ตามตำแหน่ง
                    food.GetComponent<Rigidbody>().isKinematic = true;
                    //ทำลายจานที่อยู่ในมือ
                    Destroy(hand.transform.GetChild(0).gameObject);

                    Vector3 katapos = hand.GetComponent<HandCheck>().badMatupayad.gameObject.transform.position; //เก็บตำแหน่งของกระทะไว้ที่ katapos
                    //ปิดSmoke
                    hand.GetComponent<HandCheck>().badMatupayad.gameObject.GetComponent<BadfoodBar>().smoke.gameObject.SetActive(false);

                    //ทำลายกระทะขนมครก
                    Destroy(hand.GetComponent<HandCheck>().badMatupayad);

                    //สร้างกระทะขึ้นมาใหม่
                    GameObject mt = Instantiate(kataMatupayad, katapos, Quaternion.identity);
                    mt.GetComponent<ChangMatapayad>().CookingBar = hand.GetComponent<HandCheck>().badMatupayad.gameObject.GetComponent<BadfoodBar>().CookingBar;
                    //ใส่Fire ใน mt
                    mt.GetComponent<ChangMatapayad>().Fire = hand.GetComponent<HandCheck>().badMatupayad.gameObject.GetComponent<BadfoodBar>().Fire;
                    //ใส่Smoke ใน mt
                    mt.GetComponent<ChangMatapayad>().smoke = hand.GetComponent<HandCheck>().badMatupayad.gameObject.GetComponent<BadfoodBar>().smoke;


                    //เปลี่ยนเป็นสีเขียว
                    Color color = new Color(55f / 255f, 233f / 255f, 55f / 255f);
                    mt.GetComponent<ChangMatapayad>().CookingBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
                }
            }
        }
        else
        {
            anim.SetBool("Pick", false);
        }
        //drop item
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.SetInteger("Condition", 1);
            anim.SetBool("PickDrop", true);
            if (hand.transform.childCount > 0)
            {
                hand.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                hand.transform.GetChild(0).SetParent(null);
            }
        }
        else
        {
            anim.SetBool("PickDrop", false);
        }
        
        //ถ้าไม่มีของในมือ
        if(hand.transform.GetComponent<HandCheck>().obj == null)
        {
            //ControlPlayer
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir = new Vector3(0, 0, 2) * speed;
                anim.SetBool("Walk", true);
                //anim.SetInteger("Condition", 1);
                //moveDir = transform.TransformDirection(moveDir);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir = new Vector3(0, 0, -2) * speed;
                anim.SetBool("Walk", true);
                //anim.SetInteger("Condition", 1);
                //moveDir = transform.TransformDirection(moveDir);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDir = new Vector3(2, 0, 0) * speed;
                anim.SetBool("Walk", true);
                //anim.SetInteger("Condition", 1);
                //moveDir = transform.TransformDirection(moveDir);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDir = new Vector3(-2, 0, 0) * speed;
                anim.SetBool("Walk", true);
                //anim.SetInteger("Condition", 1);
                //moveDir = transform.TransformDirection(moveDir);
            }
            else
            {
                moveDir = Vector3.zero;
                //anim.SetInteger("Condition", 0);
                anim.SetBool("Walk", false);
            }
        }
        //ถ้ามีของในมือ
        if (hand.transform.GetComponent<HandCheck>().obj != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir = new Vector3(0, 0, 2) * speed;
                anim.SetBool("PickWalk", true);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir = new Vector3(0, 0, -2) * speed;
                anim.SetBool("PickWalk", true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDir = new Vector3(2, 0, 0) * speed;
                anim.SetBool("PickWalk", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDir = new Vector3(-2, 0, 0) * speed;
                anim.SetBool("PickWalk", true);
            }
            else
            { 
                moveDir = Vector3.zero;
                anim.SetBool("PickWalk", false);
            }
        }
        
        //หันตัวละคร
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            /*transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), rotationSpeed * Time.deltaTime);*/  //หันแบบเร็ว
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

}
