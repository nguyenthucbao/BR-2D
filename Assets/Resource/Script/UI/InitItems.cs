using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class InitItems : MonoBehaviour
{
    public List<GameObject> listItems = new List<GameObject>();
    public GameObject equipedWeapon;
    public Transform weaponHand;
    public Button chooseButton;

    public LayerMask weaponLayer;
    // Start is called before the first frame update
    void Start()
    {
        chooseButton.onClick.AddListener(() => ClaimButtonClick());
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

    //public void InitWeapons()
    //{
    //    equipedWeapon = listItems[0];
    //    SwitchWeapon();

    //    foreach (Transform obj in weaponHand)
    //    {
    //        Destroy(obj.gameObject);
    //    }       
    //    Debug.Log(equipedWeapon.name);
    //    Instantiate(ItemsManager.Instance.GetHandingWeaponByName(equipedWeapon.name), weaponHand);

    //}
    //public void SwitchWeapon()
    //{
    //    Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, weaponLayer);
    //    if (equipedWeapon != null)
    //    {
    //        Instantiate(ItemsManager.Instance.GetWeaponByName(equipedWeapon.name), hit.transform);
    //    }
    //    //Debug.Log("Destroying: " + hit.gameObject.name);
    //    Destroy(hit.gameObject);
    //}


    public void InitWeapons()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.5f, weaponLayer))
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, weaponLayer);

            equipedWeapon = hit.gameObject;

            if (equipedWeapon != null)
            {
                Instantiate(ItemsManager.Instance.GetWeaponByName(equipedWeapon.name), hit.transform);
            }
            Destroy(hit.gameObject);

            foreach (Transform obj in weaponHand)
            {
                Destroy(obj.gameObject);
            }
            Debug.Log(equipedWeapon.name);
            Instantiate(ItemsManager.Instance.GetHandingWeaponByName(equipedWeapon.name), weaponHand);

        }

    }
    
}
