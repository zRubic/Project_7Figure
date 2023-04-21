using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///�����Ȳ����ͷ���������LivingEntity���У�����������Ҫ��������̳У�
///����ͬʱ�̳�IDamagable�ӿڣ��Ա㴦������߼������ƺ�Ҳ���Բ��̳нӿڣ�ֱ���ڴ�����д���˷�����
public class LivingEntity : MonoBehaviour//,IDamagable
{
    public float startingHealth;
    public event System.Action OnDeathEvent;
    //protected���εĳ�Ա���ڴ��࣬�ͼ̳д�������У������Ա�ֱ�ӵ��ã�
    protected float health;
    protected bool isDead;
    //virtual���εķ��������ڼ̳д�������У���base.Start���ã�������ȷ�����ߵ�Start����ִ�У�
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
