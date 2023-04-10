using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public float msShotCD = 100f;
    public float msReloadCD = 3000f;
    public int magCap = 5;
    public int currentAmmo;
    public float muzzleSpeed = 35f;
    public bool isReloading;

    float shotTiming;
    float reloadTiming;
    readonly string reloadKey01 = "R";
    public void Start(){
        currentAmmo = magCap;
    }
    /// <summary>
    /// 弹夹逻辑说明——
    /// 按装填键或直接调用（如行为AI）装填方法时，进入装填状态；
    /// 未在射击，且弹夹不满时，经过预设短时间后，会自动进入装填状态；
    /// 装填状态下，若弹夹不空，且接收扣扳机命令时，打断装填状态，再度装填时重新计时；
    /// 装填状态下，若弹夹已空，则不会响应扣扳机命令，直至此次装填完成，解除装填状态；
    /// </summary>
    public void ProceedFire()
    {
        if (Time.time > shotTiming && currentAmmo>=1)
        {
            isReloading = false;
            FireBullet();
            if (currentAmmo <= 0)
            {
                isReloading = true;
            }
        }
    }
    void FireBullet()
    {
        shotTiming = Time.time + msShotCD / 1000f;
        Projectile flyingBullet = Instantiate(projectile, muzzle.position, muzzle.rotation);
        flyingBullet.SetSpeed(muzzleSpeed);
        currentAmmo--;
    }
    private void Update()
    {

    }
}
