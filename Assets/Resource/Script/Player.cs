
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    public Joystick movementJS;
    public Joystick shootingJS;
    private Rigidbody2D rb;

    public float speed = 6f;
    public bool isShooting = false;

    private Coroutine shootingCoroutine;

    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 1000f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        PlayerMovement();
        if (shootingJS.Direction.magnitude > 0.5f)
        {
            StartShooting();
        }
        else
        {
            StopShooting();
        }
    }

    public void PlayerMovement()
    {
        if (movementJS.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJS.Direction.x * speed, movementJS.Direction.y * speed);
            if (PlayerShooting())
            {
                FacingTo(shootingJS.Direction);
            }
            else
            {
                FacingTo(movementJS.Direction);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            FacingTo(shootingJS.Direction);
        }
    }
    public bool PlayerShooting()
    {
        if (shootingJS.Direction.y != 0)
        {
            isShooting = true;
            return true;
        }
        else
        {
            isShooting = false;
            return false;
        }
    }
    public void FacingTo(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void Death()
    {
        Debug.Log("RUDEATH");
        Destroy(gameObject);
    }

    IEnumerator ShootCoroutine()
    {
        while (shootingJS.Direction.magnitude > 0.5f)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<PistonBullet>().seft = this;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shootingJS.Direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.4f);
        }
        shootingCoroutine = null;
    }
    private void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
    private void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootCoroutine());
        }
    }

}
