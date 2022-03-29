using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        //agent에게 목적지를 알려주고싶다.
        agent.destination = target.transform.position;
    }
}
