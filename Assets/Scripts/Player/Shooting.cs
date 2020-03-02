using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject Airbullet;
    private Vector2 startingPoint;
    private int leftTouch = 99;


    public float AirBulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //ShootAir();
        //}
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2)
                {
                    ShootAir();
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }

        }

        void ShootAir()
        {
            GameObject bullet1 = Instantiate(Airbullet, Muzzle.position, Muzzle.rotation);
            Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
            rb.AddForce(Muzzle.up * AirBulletForce, ForceMode2D.Impulse);

            Destroy(bullet1.gameObject, 0.1f);
        }

        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }
    }
}
