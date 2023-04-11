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
    //override���εķ������Ḳ�ǻ����е�ͬ��������������û��෽������base���У�
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
    //������update�и���Ѱ·Ŀ�ĵأ��������Ĺ��ߣ�����coroutine���Ե��͸���Ƶ�ʣ�
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
