using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public List<GameObject> spawnList = new List<GameObject>();
    public GameObject piston;

    // Start is called before the first frame update
    void Start()
    {
        SetupItems();
    }

    // Update is called once per frame

    public void SetupItems()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            Instantiate(piston, spawnList[i].transform.position, Quaternion.identity);

        }
    }


}
