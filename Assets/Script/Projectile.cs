using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3f;
    public LayerMask collisionMask;
    public float damage = 5f;
    //
    float speed = 10f;
    float birthTiming;
    // Start is called before the first frame update
    void Start()
    {
        birthTiming = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        float frameDistance = speed * Time.deltaTime;
        CheckCollision(frameDistance);
        transform.Translate(Vector3.forward * frameDistance);
        CheckLifeTime();
    }
    //
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    //
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
    //
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    //
    public void CheckLifeTime()
    {
        if (Time.time > birthTiming + lifeTime)
        {
            OnDestroy();
        }
    }
    //
    void CheckCollision(float checkDistance)
    {
        //以子弹自身位置为原点，以前方向为方向，发射射线；
        Ray checkRay = new(transform.position, transform.forward);
        ///射线检测惯用方法
        ///Physics.Raycast检测射线的碰撞情况
        ///out返回碰撞对象的信息，类型根据参数定义确定；RaycastHit是结构体；
        ///collisionMask表示射线碰撞需要检测的Layer
        ///以下是G老师对这个方法的详细解释（太敬业了，泪目）——
        ///checkRay: A Ray object that defines the origin and direction of the raycast. 
        ///The raycast will start from the origin and travel in the specified direction.
        ///out hit: An out parameter of type RaycastHit. If the raycast hits a collider, 
        ///the method will store the hit information(such as the point of impact, the distance traveled, 
        ///and the GameObject that was hit) in the hit variable.
        ///checkDistance: A float value that determines the maximum distance the ray should travel.
        ///The raycast will stop after traveling this distance, even if it hasn't hit any colliders.
        ///collisionMask: A LayerMask that filters the colliders the raycast should interact with.
        ///Only colliders in the specified layers will be considered for intersection with the ray.
        ///QueryTriggerInteraction.Collide: 
        ///An enumeration value that specifies how the raycast should interact with trigger colliders.
        ///In this case, 
        ///QueryTriggerInteraction.Collide means that the raycast will interact with both trigger and non - trigger colliders.
        ///Other options are QueryTriggerInteraction.Ignore(to ignore trigger colliders) 
        ///and QueryTriggerInteraction.UseGlobal(to use the global settings defined in the Physics Manager).
        ///The method returns a bool value: true if the raycast hits a collider, and false otherwise.
        ///By checking the return value, you can determine whether the raycast hit something or not, 
        ///and take appropriate actions based on that information. 
        ///
        RaycastHit hit;
        if (Physics.Raycast(checkRay,out hit,checkDistance,collisionMask,QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }
    //
    private void OnHitObject(RaycastHit theHit)
    {
        //Debug.Log(theHit.collider.gameObject.name);
        //IDamagable damagableObject = theHit.collider.GetComponent<IDamagable>();
        LivingEntity damagableObject = theHit.collider.GetComponent<LivingEntity>();
        if (damagableObject != null)
        {
            damagableObject.TakeHit(damage,theHit);
        }
        OnDestroy();
    }
}
