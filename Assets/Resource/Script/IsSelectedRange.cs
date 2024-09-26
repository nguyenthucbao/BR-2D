using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSelectedRange : MonoBehaviour
{
    public List<GameObject> listItems = new List<GameObject>();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            Debug.Log("hit");
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
}
