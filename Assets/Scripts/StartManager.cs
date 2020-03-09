using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    
    public void Play()
    {
 
        SceneManager.LoadScene("Main");
    }

    public void Info()
    {

        SceneManager.LoadScene("Info Scene");
    }

    public void Back()
    {

        SceneManager.LoadScene("Title Scene");
    }

}
