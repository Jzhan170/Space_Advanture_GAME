using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [Header("Shooting variables")]
    public GameObject bullet;
    private float shootDelay = 3f;
    private int bulletSpeed = 500;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Determines whether or not the enemy can fire again.
    /// </summary>
    void ResetShot()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If statement which creates a bullet which fires upward and then sets the canShoot
        //bool to false in order to stop firing and wait for the Shoot Delay before firing again.
        if (canShoot)
        {
            //Vector3 spawnPoint = transform.position + transform.up;


            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;

            //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
    }
}
