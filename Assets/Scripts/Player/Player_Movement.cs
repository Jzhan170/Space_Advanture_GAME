using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Camera cam;

    Vector2 movement;
    Vector2 touchPos;

    public Joystick joystick;

    public VectorValues startingPosition;

    

    void Start()
    {
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    
        //if(Input.touchCount > 0)
        //{
            //Touch touch = Input.GetTouch(0);
            //touchPos = cam.ScreenToWorldPoint(touch.position);
        //}
        //touchPos = cam.ScreenToWorldPoint(touch.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        //Vector2 lookDir = touchPos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
       // rb.rotation = angle;
    }
}
