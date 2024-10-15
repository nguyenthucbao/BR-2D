using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Piston : MonoBehaviour
{
    public GameObject handingWeapon;
    public GameObject groundingWeapon;

    public GameObject bullet;
    public float shootingDelay = 0.5f;
    public float numberOfBullet = 12;

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
