using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Camera cam;

    Vector2 movement;
    Vector2 touchPos;

    public Joystick joystick;

    public VectorValues startingPosition;

    AudioSource audioS;
    public AudioClip bump;


    void Start()
    {
        transform.position = startingPosition.initialValue;

        audioS = GetComponent<AudioSource>();

        audioS.clip = bump;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("Border"))
        {
            audioS.Play();
        }
    }

    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement != Vector2.zero)
        {
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
        //Vector2 lookDir = touchPos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
       // rb.rotation = angle;
    }
}
