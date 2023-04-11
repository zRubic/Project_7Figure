using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy00 : MonoBehaviour
{
    public Transform pursuitTarget;
    NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        pursuitTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(pursuitTarget.transform.position);
    }
}
