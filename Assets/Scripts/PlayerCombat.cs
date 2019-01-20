using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    public GameObject currentWeaponObj = null;
    public ObjectInteract currentInterObjScript = null;
    public AICombat currentCombatScript = null;

    public GameObject weapon;
    public List<GameObject> weapons;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && currentWeaponObj)
        {
            if (currentInterObjScript.hasWeapon)
            {
                weapons.Add(weapon);
                currentInterObjScript.pickUpWeapon();
                currentWeaponObj = null;
                Debug.Log("You picked up the weapon");
            }

            if (weapons.Count > 0)
            {
                currentCombatScript.KOGuard();
                weapons.Remove(weapon);
                Debug.Log("Guard Knocked Out");
            }
        }
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            Debug.Log(other.name);
            currentWeaponObj = other.gameObject;
            currentCombatScript = currentWeaponObj.GetComponent<AICombat>();

        }
        if (other.CompareTag("Interactable Object"))
        {
            Debug.Log(other.name);

            currentWeaponObj = other.gameObject;
            currentInterObjScript = currentWeaponObj.GetComponent<ObjectInteract>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable Object"))
        {
            if (other.gameObject == currentWeaponObj)
            {
                currentWeaponObj = null;
            }

        }
    }
}
