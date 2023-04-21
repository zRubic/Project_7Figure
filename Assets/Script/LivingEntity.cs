using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///生死等参数和方法，放在LivingEntity类中，方便其他需要生死的类继承；
///此类同时继承IDamagable接口，以便处理承伤逻辑；（似乎也可以不继承接口，直接在此类里写承伤方法）
public class LivingEntity : MonoBehaviour//,IDamagable
{
    public float startingHealth;
    public event System.Action OnDeathEvent;
    //protected修饰的成员，在此类，和继承此类的类中，都可以被直接调用；
    protected float health;
    protected bool isDead;
    //virtual修饰的方法，可在继承此类的类中，用base.Start调用，这样可确保两边的Start都能执行；
    public virtual void Start()
    {
        health = startingHealth;
    }
    public void TakeHit(float theDamage,RaycastHit theHit)
    {
        health -= theDamage;
        Debug.Log(gameObject.name + "'s health:" + health);
        if (health <= 0 && !isDead)
        {
            OnDie();
        }
    }
    public void OnDie()
    {
        Die();
    }
    public void Die()
    {
        isDead = true;
        if (OnDeathEvent!=null)
        {
            OnDeathEvent();
        }
        Destroy(gameObject);
    }
}
