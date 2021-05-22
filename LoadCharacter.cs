using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    //public GameObject[] kitchenware;
    public GameObject[] spawn;
    public GameObject time;
    public GameObject ctrl_player;
    //public GameObject goodfood;
    //public GameObject[] Obj;
    

    void Awake()
    {
        int selecCharacter = PlayerPrefs.GetInt("selecCharacter");
        GameObject prefab = characterPrefabs[selecCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        //define hand
        clone.GetComponent<CTRL_Player>().hand = clone.transform.GetChild(0).gameObject;

        time.GetComponent<TimeLefts>().player = clone;

        spawn[0].GetComponent<CTRL_Food>().Player = clone;
        spawn[1].GetComponent<CTRL_Food>().Player = clone;
        spawn[2].GetComponent<CTRL_Food>().Player = clone;
        spawn[3].GetComponent<CTRL_Food>().Player = clone;

        ctrl_player.GetComponent<Item>().CTRL_Player = clone;

        //goodfood.GetComponent<HandCheck>().Player = clone;

        /*kitchenware[0].GetComponent<Food>().Player = clone;
        kitchenware[0].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        kitchenware[1].GetComponent<Food>().Player = clone;
        kitchenware[1].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        kitchenware[2].GetComponent<Food>().Player = clone;
        kitchenware[2].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        kitchenware[3].GetComponent<Food>().Player = clone;
        kitchenware[3].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;*/

        

        /*Obj[0].GetComponent<Food>().Player = clone;
        Obj[0].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        Obj[1].GetComponent<Food>().Player = clone;
        Obj[1].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        Obj[2].GetComponent<Food>().Player = clone;
        Obj[2].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;
        Obj[3].GetComponent<Food>().Player = clone;
        Obj[3].GetComponent<Food>().theDest = clone.transform.GetChild(0).transform;*/




    }


}
