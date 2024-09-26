using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitItems : MonoBehaviour
{
    public Transform weaponHand;
    public Button chooseButton;
    // Start is called before the first frame update
    void Start()
    {
        chooseButton.onClick.AddListener(() => ClaimButtonClick());
    }

    public void ClaimButtonClick()
    {
        InitWeapons();
    }

    public void InitWeapons()
    {
        foreach (Transform obj in weaponHand)
        {
            Destroy(obj.gameObject);
        }
        Instantiate(ItemsManager.Instance.GetWeapon(), weaponHand);
        Debug.Log("taken");
    }
}
