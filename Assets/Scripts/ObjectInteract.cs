using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour {

    public bool openDoor;
    public bool closeDoor;
    public bool talks;
    public bool canInteract;
    public bool isOpen = false;
    
    public GameObject Player;
    public GameObject door;

    public void CanInteract()
    {
        Debug.Log("Press E to Interact.");
    }

    public void open()
    {
        door.SetActive(false);
        isOpen = true;
    }

    public void close()
    {
        door.SetActive(true);
        isOpen = false;
    }
}
