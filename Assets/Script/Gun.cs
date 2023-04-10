using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public float msShotCD = 100f;
    public float msReloadCD = 3000f;
    public float magCap = 20f;
    public float muzzleSpeed = 35f;

    float shotTiming;
    public void ProceedFire()
    {
        if (Time.time>shotTiming)
        {
            shotTiming = Time.time + msShotCD / 1000f;
            Projectile flyingBullet = Instantiate(projectile, muzzle.position, muzzle.rotation);
            flyingBullet.SetSpeed(muzzleSpeed);
        }
    }
}
