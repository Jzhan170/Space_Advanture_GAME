using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagshowandhide : MonoBehaviour
{
    public GameObject BagPanel;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showhidePanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            BagPanel.gameObject.SetActive(false);
        }
        else
        {
            BagPanel.gameObject.SetActive(true);
        }
    }
}
