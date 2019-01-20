using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {

    //create the game objects to be referenced in this script
    public GameObject currentInterObj = null;
    public GameObject currentEnemy = null;
    public ObjectInteract currentInterObjScript = null;
    public AICombat currentCombatScript = null;

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
                currentInterObj = null;
                Debug.Log("You picked up the key");
            }

            if (currentInterObjScript.hasWeapon)
            {
                weapons.Add(weapon);
                currentInterObjScript.pickUpWeapon();
                currentInterObj = null;
                Debug.Log("You picked up the weapon");
            }

            if (currentInterObjScript.hasFile)
            {
                files.Add(file);
                currentInterObjScript.pickUpFile();
                currentInterObj = null;
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
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.buildIndex + 1);
                }
              /* if(currentCombatScript.isGuard && weapons.Count > 0)
            {
                currentCombatScript.KOGuard();
                weapons.Remove(weapon);
                Debug.Log("Guard Knocked Out");
            }*/

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
        /*if (other.CompareTag("Guard"))
        {
            Debug.Log(other.name);
            currentEnemy = other.gameObject;
            currentCombatScript = currentEnemy.GetComponent<AICombat>();

        }*/
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
