using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3f;

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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        SelfDespawn();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void SelfDespawn()
    {
        if (Time.time>birthTiming+lifeTime)
        {
            OnDestroy();
        }
    }
}
