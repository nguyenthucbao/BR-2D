using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBullet : MonoBehaviour
{

    private Coroutine shootingCoroutine;

    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 1000f;

    public Joystick shootingJS;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(shootingPoint.position.x + " " + shootingPoint.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingJS.Direction.magnitude > 0.1f)
        {
            StartShooting();
        }
        else
        {
            StopShooting();
        }
    }


    IEnumerator ShootCoroutine()
    {
        while (shootingJS.Direction.magnitude > 0.1f) 
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shootingJS.Direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            Debug.Log(shootingJS.Direction.x + " " + shootingJS.Direction.y);

            yield return new WaitForSeconds(1f);
        }
        shootingCoroutine = null;
    }

    private void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            Debug.Log("stop CRT");
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            Debug.Log("new CRT");
            shootingCoroutine = StartCoroutine(ShootCoroutine());
        }
    }
}
