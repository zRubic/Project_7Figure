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
    //fixedUpdate多用于物理，它时间固定，因此刚体移动要放在这里，而move方法只改速度参数；
    //否则不能确定刚体每帧移动的时间，也就无法准确控制速度；
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
