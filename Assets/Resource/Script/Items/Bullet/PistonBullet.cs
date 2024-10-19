using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PistonBullet : MonoBehaviour
{
    public InitItems seft;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<Player>() != seft)
        {
            Debug.Log("Hit");
            collision.GetComponent<Player>().Death();
            Destroy(gameObject);
        }
    }

}
