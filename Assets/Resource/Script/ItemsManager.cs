using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{
    public List<GameObject> listWeapon = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject GetWeaponByName(string wpName)
    {
        for (int i = 0; i <= listWeapon.Count; i++)
        {
            if(listWeapon[i].name == wpName) return listWeapon[i];
        }
        return null;
    }
}
