using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleInteraction : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject collectibleInteract;
    private bool triggerEntered = false;
    // Update is called once per frame
    void Update()
    {
        OpenLetter();
    }
    
    private void OnTriggerEnter(Collider other)
    { 
        triggerEntered = true;
    }
    
    private void OnTriggerExit(Collider other)
    { 
        triggerEntered = false;
    }

    private void OpenLetter()
    {
        if (triggerEntered)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                uiManager.OpenLetter();
            }
        }
    }
    
}