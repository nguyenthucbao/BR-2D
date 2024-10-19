using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : MonoBehaviour
{
    public GameObject handingWeapon;
    public GameObject groundingWeapon;

    public GameObject bullet;
    public float shootingDelay = 0.1f;
    public float numberOfBullet = 30;

    public void Start()
    {
        handingWeapon.SetActive(false);
        groundingWeapon.SetActive(true);
    }
    public void SetWeaponState(bool isInHand)
    {
        if (isInHand)
        {
            handingWeapon.SetActive(true);
            groundingWeapon.SetActive(false);
        }
        else
        {
            handingWeapon.SetActive(false);
            groundingWeapon.SetActive(true);
        }
    }

}
