using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour {

    public bool openDoor;
    public bool closeDoor;
    public bool hasKey;
    public bool canInteract;
    
    public GameObject Player;
    public GameObject door;
    public GameObject keyCard;

    public void CanInteract()
    {
        Debug.Log("Press E to Interact.");
    }

    public void open()
    {
        door.SetActive(false);      
    }

    public void close()
    {
        door.SetActive(true);
    }

    public void pickUp()
    {
        keyCard.SetActive(false);
        hasKey = true;
    }
}
