using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemProjectile : MonoBehaviour
{
    private float moveSpeed = 7f;
    Vector2 moveDirection;
    Player target;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Find any object of type Player
        target  = GameObject.FindObjectOfType<Player>();
        //Sets the direction of the projectile to look for the player target's position 
        //and then normalizes the move speed in order to make it smoother.
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        //Applies move forces to objects rigidbody to move it
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
    }

    
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Do something
            Destroy(gameObject);
        }
    }
}
