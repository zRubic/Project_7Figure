using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunHolder;
    public Gun initialGun;
    
    
    Gun currentGun;

    public void Start()
    {
        if (initialGun!=null)
        {
            EquipGun(initialGun);
        }
    }

    public void EquipGun(Gun gun2Equip) {
        if (currentGun!=null)
        {
            Destroy(currentGun.gameObject);
        }
        currentGun = Instantiate(gun2Equip, gunHolder.position, gunHolder.rotation);
        currentGun.transform.parent = gunHolder;
    }

    public void PullTrigger()
    {
        if (currentGun != null)
        {
            currentGun.ProceedFire();
        }
    }
}
