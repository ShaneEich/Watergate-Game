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
        if (Input.GetButtonDown("Attack") && currentEnemy)
        {
            if (weapons.Count > 0)
            {
                currentEnemy.SetActive(false);
                weapons.Remove(weapon);
                Debug.Log("Guard Knocked Out");
            }else if(weapons.Count <= 0)
            {
                Debug.Log("No weapons available.");
            }
        }
    }

    //check if the player is colliding with a trigger and display the trigger's name
    void OnTriggerEnter(Collider collider)
    {
        // Check if in trigger of object and collect objects script
        if (collider.CompareTag("Interactable Object"))
        {
            Debug.Log(collider.name);

            currentInterObj = collider.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<ObjectInteract>();
        }
        if (collider.CompareTag("Guard"))
        {
            Debug.Log(collider.name);
            currentEnemy = collider.gameObject;
            //currentCombatScript = currentEnemy.GetComponent<AICombat>();

        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Interactable Object"))
        {
            if (collider.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }else if (collider.CompareTag("Guard"))
        {
            if(collider.gameObject == currentEnemy)
            {
                currentEnemy = null;
            }
        }
    }
}
