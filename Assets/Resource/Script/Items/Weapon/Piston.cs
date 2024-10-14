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
        //if (handingWeapon == null)
        //{
        //    Debug.LogError("handingWeapon is not assigned in the Inspector");
        //}
        //if (groundingWeapon == null)
        //{
        //    Debug.LogError("groundingWeapon is not assigned in the Inspector");
        //}

        if (isInHand)
        {
            
            
            Debug.Log("handingWeaponSetActive");
            handingWeapon.SetActive(true);      
            groundingWeapon.SetActive(false);   
        }
        else
        {
            Debug.Log("groundingWeaponSetActive");
            handingWeapon.SetActive(false);     
            groundingWeapon.SetActive(true);    
        }
    }

}
