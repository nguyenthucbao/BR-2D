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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if (movementJS.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJS.Direction.x * speed, movementJS.Direction.y * speed);
            if ( PlayerShooting())
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

    public void FacingTo(Vector2 direction)
    {
        //Vector2 direction = movementJS.Direction;
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public bool PlayerShooting()
    {
        if (shootingJS.Direction.y != 0)          
        {
            isShooting = true;
            return true;
        } else
        {
            isShooting = false;
            return false;
        }    
    }



}
