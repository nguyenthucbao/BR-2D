using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class InitItems : MonoBehaviour
{
    public List<GameObject> listItems = new List<GameObject>();
    public Transform weaponHand;
    public Button chooseButton;
    public LayerMask weaponLayer;
    public GameObject equipedWeapon;

    public GameObject rightHand;
    public GameObject leftHand;

    private Coroutine shootingCoroutine;
    public Joystick shootingJS;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 1000f;
    public enum WeaponType
    {
        Piston,
        M4A1,
    }

    // Start is called before the first frame update
    void Start()
    {
        chooseButton.onClick.AddListener(() => ClaimButtonClick());
    }

    void Update()
    {
        if (shootingJS != null && shootingJS.Direction.magnitude > 0.5f && !rightHand.activeInHierarchy)
        {
            StartShooting();
        }
        else
        {
            StopShooting();
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            listItems.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            listItems.Remove(collision.gameObject);
        }
    }


    public void ClaimButtonClick()
    {
        if (listItems.Count != 0) 
        {
            InitWeapons();
        } 
        
    }

    public void InitWeapons()
    {
        //foreach (Transform obj in weaponHand)
        //{
        //    Destroy(obj.gameObject);
        //}
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, weaponLayer);

        if (hit != null)
        {
            Debug.Log("Hit object: " + hit.gameObject.name);
            DropWeapon();

            Piston piston = hit.GetComponent<Piston>();
            piston.SetWeaponState(true);

            hit.gameObject.transform.position = weaponHand.position;
            hit.gameObject.transform.SetParent(weaponHand);
            hit.gameObject.transform.localRotation = Quaternion.identity;

            rightHand.SetActive(false);
            leftHand.SetActive(false);
        }
       
    }
    public void DropWeapon()
    {
        if (!rightHand.activeInHierarchy)
        {
            Piston piston = weaponHand.GetComponentInChildren<Piston>();
            if (piston != null)
            {
                piston.transform.SetParent(null);
                piston.SetWeaponState(false);
                piston.transform.rotation = Quaternion.identity;
            }
            else
            {
                Debug.LogError("Piston not found!!!!!!!!!!!");
            }
        }   
    }

    IEnumerator ShootCoroutine()
    {
        while (shootingJS.Direction.magnitude > 0.5f)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<PistonBullet>().seft = this;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shootingJS.Direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.4f);
        }
        shootingCoroutine = null;
    }
    private void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
    private void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootCoroutine());
        }
    }
}
