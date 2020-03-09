using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEn : MonoBehaviour
{
    public float speed ;
    private Rigidbody2D rb;
    private Transform target;

    public float Chaseing_Stop_Distance;
    //public float ChaseDistance;
    public float retreatDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > Chaseing_Stop_Distance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 temp = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(temp);
            //Flip();
        } else if(Vector2.Distance(transform.position, target.position) < Chaseing_Stop_Distance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            Vector3 temp = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            rb.MovePosition(temp);
        }
    }
    /// <summary>
    /// Allows for sprite to flip its direction to seem as though it turns 
    /// </summary>
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
