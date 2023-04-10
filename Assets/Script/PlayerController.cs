using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 velocity;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 pVelocity)
    {
        velocity = pVelocity;
    }
    //fixedUpdate������������ʱ��̶�����˸����ƶ�Ҫ���������move����ֻ���ٶȲ�����
    //������ȷ������ÿ֡�ƶ���ʱ�䣬Ҳ���޷�׼ȷ�����ٶȣ�
    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
    public void PlayerLookAt(Vector3 lookPoint)
    {
        Vector3 heightLookPoint = new(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightLookPoint);
    }
}
