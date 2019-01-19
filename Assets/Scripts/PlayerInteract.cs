using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public ObjectInteract currentInterObjScript = null;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.openDoor)
            {
                currentInterObjScript.open();
            }

            if (currentInterObjScript.closeDoor)
            {
                currentInterObjScript.close();
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if in trigger of object and collect objects script
        if (other.CompareTag("Interactable Object"))
        {
            Debug.Log(other.name);

            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<ObjectInteract>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable Object"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
}
