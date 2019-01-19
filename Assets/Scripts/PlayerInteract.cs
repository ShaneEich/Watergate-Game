using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public ObjectInteract currentInterObjScript = null;
    public GameObject keyCard;
    public List<GameObject> keyCards;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.hasKey)
            {
                keyCards.Add(keyCard);
                currentInterObjScript.pickUp();
                Debug.Log("You picked up the key");
            }

            
                if (currentInterObjScript.openDoor && keyCards.Count > 0)
            {
                    currentInterObjScript.open();
                    Debug.Log("Door is open");
                }
            
            
                if (currentInterObjScript.closeDoor && keyCards.Count > 0)
                {
                    currentInterObjScript.close();
                    keyCards.Remove(keyCard);
                    Debug.Log("Door is closed");
                    SceneManager.LoadScene("Level1");
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
