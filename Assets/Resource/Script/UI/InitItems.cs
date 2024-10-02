using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitItems : MonoBehaviour
{
    public List<GameObject> listItems = new List<GameObject>();

    public Transform weaponHand;
    public Button chooseButton;
    // Start is called before the first frame update
    void Start()
    {
        chooseButton.onClick.AddListener(() => ClaimButtonClick());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            Debug.Log(collision.gameObject.name);
            listItems.Add(collision.GetComponent<GameObject>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            listItems.Remove(collision.GetComponent<GameObject>());
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
        foreach (Transform obj in weaponHand)
        {
            Destroy(obj.gameObject);
        }
        Instantiate(ItemsManager.Instance.GetWeaponByName(listItems[0].name), weaponHand);
        Debug.Log("taken");
    }
}
