using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour {

    public bool openDoor; 
    public bool talks;
    public bool canInteract;
    public string tutorialMessage;
    public string message; 
    
    public GameObject Player;
    public GameObject door;

    public void Talk()
    {
        // If Interactable object can talk display message
        Debug.Log(message);
    }

    public void CanInteract()
    {
        Debug.Log("Press E to Interact.");
    }

    public void open()
    {
        door.SetActive(false);
    }
}
