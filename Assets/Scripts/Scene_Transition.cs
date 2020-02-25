using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{

    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorValues playerStorage;

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
