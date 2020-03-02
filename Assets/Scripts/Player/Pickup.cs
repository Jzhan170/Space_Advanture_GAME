using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pickup : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip collected;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();

        audioS.clip = collected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched"+other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked");
            audioS.Play();
            scorescript.scoreValue += 1;
            Destroy(gameObject, .1f);
            
        }
    }
}
