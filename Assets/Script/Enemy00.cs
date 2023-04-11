using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy00 : LivingEntity
{
    public Transform pursuitTarget;
    NavMeshAgent navAgent;
    //override修饰的方法，会覆盖基类中的同名方法，如需调用基类方法，用base呼叫；
    public override void Start()
    {
        base.Start();
        navAgent = GetComponent<NavMeshAgent>();
        pursuitTarget = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }
    //
    void Update()
    {

    }
    //不宜在update中更新寻路目的地，可能消耗过高；改用coroutine，以调低更新频率；
    IEnumerator UpdatePath()
    {
        float pathUpdatingRate = 0.5f;
        while (pursuitTarget!=null)
        {
            Vector3 targetGroundPos = new(pursuitTarget.position.x, 0, pursuitTarget.position.z);
            if (!isDead)
            {
                navAgent.SetDestination(targetGroundPos);
            }
            yield return new WaitForSeconds(pathUpdatingRate);
        }
    }
}
