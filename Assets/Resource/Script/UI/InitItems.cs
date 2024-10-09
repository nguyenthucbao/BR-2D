using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

    public string equipedWeapon;
    public GameObject equipedWeaponObj;

    public GameObject rightHand;
    public GameObject leftHand;

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


    //Debug
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
    //Debug

    public void ClaimButtonClick()
    {
        if (listItems.Count != 0) 
        {
            InitWeapons();
        } 
        
    }
    public void InitWeapons()
    {
        foreach (Transform obj in weaponHand)
        {
            Destroy(obj.gameObject);
        }

        //Switch weapon
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, weaponLayer);

        if (Enum.IsDefined(typeof(WeaponType), equipedWeapon))
        {
            Debug.Log(equipedWeapon);
            Instantiate(ItemsManager.Instance.GetWeaponByName(equipedWeapon), hit.transform.position, Quaternion.identity);
        }
        //Switch weapon

        rightHand.SetActive(false);
        leftHand.SetActive(false);

        equipedWeapon = hit.gameObject.name.Replace("(Clone)", "").Trim();
        Debug.Log(equipedWeapon);

        Instantiate(ItemsManager.Instance.GetHandingWeaponByName(equipedWeapon), weaponHand);
        Destroy(hit.gameObject);
    }



}
