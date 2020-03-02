using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shooting : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject Airbullet;

     

    public float AirBulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootAir();
        }

        
    }

    void ShootAir()
    {
        GameObject bullet1 = Instantiate(Airbullet, Muzzle.position, Muzzle.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(Muzzle.up * AirBulletForce, ForceMode2D.Impulse);

        Destroy(bullet1.gameObject, 0.1f);
    }
}
