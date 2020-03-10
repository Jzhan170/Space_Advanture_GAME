using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);

        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed*Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position)<0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                Flip();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    /// <summary>
    /// d Allows for sprite to flip its direction to seem as though it turns 
    /// </summary>
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
