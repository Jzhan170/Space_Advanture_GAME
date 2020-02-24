using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunned : MonoBehaviour
{
    public Sprite Stunned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Air Bullet")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Stunned;

            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);

            Debug.Log("Hit");
        }
    }
}
