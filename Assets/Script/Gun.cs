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
    /// �����߼�˵������
    /// ��װ�����ֱ�ӵ��ã�����ΪAI��װ���ʱ������װ��״̬��
    /// δ��������ҵ��в���ʱ������Ԥ���ʱ��󣬻��Զ�����װ��״̬��
    /// װ��״̬�£������в��գ��ҽ��տ۰������ʱ�����װ��״̬���ٶ�װ��ʱ���¼�ʱ��
    /// װ��״̬�£��������ѿգ��򲻻���Ӧ�۰�����ֱ���˴�װ����ɣ����װ��״̬��
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
