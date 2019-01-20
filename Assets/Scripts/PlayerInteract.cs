using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {

    //create the game objects to be referenced in this script
    public GameObject currentInterObj = null;
    public ObjectInteract currentInterObjScript = null;

    public GameObject keyCard;
    public List<GameObject> keyCards;

    public GameObject weapon;
    public List<GameObject> weapons;

    public GameObject file;
    public List<GameObject> files;

    //interact with the elevator, weapons, files, and key cards
    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.hasKey)
            {
                keyCards.Add(keyCard);
                currentInterObjScript.pickUpKey();
                Debug.Log("You picked up the key");
            }

            if (currentInterObjScript.hasWeapon)
            {
                weapons.Add(weapon);
                currentInterObjScript.pickUpWeapon();
                Debug.Log("You picked up the weapon");
            }

            if (currentInterObjScript.hasFile)
            {
                files.Add(file);
                currentInterObjScript.pickUpFile();
                Debug.Log("You picked up the file");
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

    //check if the player is colliding with a trigger and display the trigger's name
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
