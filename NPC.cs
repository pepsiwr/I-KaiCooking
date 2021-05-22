using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    Vector3 pos;
    public Transform goal_1;
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        StartNPC();
    }
    public void StartNPC()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal_1.position;


        /*if (pos != transform.position)
        {
            anim.SetBool("condition", true);
        }
        else
        {
            anim.SetBool("condition", false);
        }*/
        pos = transform.position;
    }
}
