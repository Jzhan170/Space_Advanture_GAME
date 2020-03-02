using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick_Shoot : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private Vector2 startingPoint;
    private int leftTouch = 99;
    public Joystick movement_joystick;

    public GameObject Airbullet;
    public Transform Muzzle;

    public float AirBulletForce = 20f;
    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;
            if(t.phase == TouchPhase.Began)
            {
                if(t.position.x > Screen.width / 2)
                {
                    shootBullet();
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }else if(t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                moveCharacter(direction);
            }else if(t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
            }
            ++i;
        }
    }
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        //player.Translate(direction * speed * Time.deltaTime);
    }
    void shootBullet()
    {
        GameObject bullet1 = Instantiate(Airbullet, Muzzle.position, Muzzle.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(Muzzle.up * AirBulletForce, ForceMode2D.Impulse);

        Destroy(bullet1.gameObject, 0.1f);
    }
}
