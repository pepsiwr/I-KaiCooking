using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTRL_Food : MonoBehaviour
{
    //[SerializeField] Transform Player; //ตำแหน่งPlayer
    [SerializeField] float LongDistance = 4f; //สีเขียว
    //[SerializeField] Vector3 cubecheck = Vector3.one;

    public GameObject Player;
    public GameObject PlatePrefab;
    //public Transform theDest;
    float distanceToPlayer = Mathf.Infinity; //ค่าระยะห่าง
    

    void Update()
    {
        DetectPlayer();
        
    }

    public void DetectPlayer()
    {
        distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);

        GameObject Plate;
       
        if (distanceToPlayer <= LongDistance) //ถ้าเข้าในวงสีเขียว
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //เก็บของ
                Plate = Instantiate(PlatePrefab, Player.transform.GetChild(0).transform.position, Quaternion.identity);

                //Plate.transform.position = theDest.position;
                Plate.transform.parent = GameObject.Find("Destination").transform;
                Plate.GetComponent<Rigidbody>().isKinematic = true; 
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; //ให้วงกลมสีเขียว
        Gizmos.DrawWireSphere(transform.position, LongDistance);
    }
     
}
