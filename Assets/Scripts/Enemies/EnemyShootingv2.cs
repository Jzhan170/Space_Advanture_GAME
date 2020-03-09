using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingv2 : MonoBehaviour
{
    public float speed;
    //public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float StarttimeBtwShots;

    public GameObject projectile;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = StarttimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            Shoot();
        }

        
    }

    void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = StarttimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
