using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemsManager : Singleton<ItemsManager>
{
    public List<GameObject> listHandingWeapon = new List<GameObject>();
    public List<GameObject> listWeapon = new List<GameObject>();

    public List<GameObject> spawnList = new List<GameObject>();
    public GameObject piston;

    // Start is called before the first frame update
    void Start()
    {
        SetupItems();
    }

    // Update is called once per frame
    public GameObject GetHandingWeaponByName(string wpName)
    {
        for (int i = 0; i < listHandingWeapon.Count; i++)
        {
            if(listHandingWeapon[i].name == wpName) return listHandingWeapon[i];
        }
        return null;
    }

    public GameObject GetWeaponByName(string wpName)
    {
        for (int i = 0; i < listWeapon.Count; i++)
        {
            if (listWeapon[i].name == wpName) return listWeapon[i];
        }
        return null;
    }

    public void SetupItems()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            Instantiate(piston, spawnList[i].transform.position, Quaternion.identity);

        }
    }    



}
