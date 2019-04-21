using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteract : MonoBehaviour {

    //create booleans used in this script and playerInteract
    public bool openDoor;
    public bool closeDoor;
    public bool hasKey;
    public bool hasWeapon;
    public bool hasFile;
    public bool canInteract;
    public bool hasClue;
    public bool isPiano;


    //create game objects and items used in this script
    public GameObject Player;
    public GameObject door;
    public GameObject keyCard;
    public GameObject weapon;
    public GameObject file;
    public GameObject piano;

    public Item doorItem;
    public Item keyCardItem;
    public Item weaponItem;
    public Item fileItem;

    public Animator anim;
    public AudioSource audio;
    public AudioClip Beauty;
    public AudioClip CloudChamber;
    public AudioClip StrangeDream;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void CanInteract()
    {
        //need to add an on screen pop up for all interactable objects
        Debug.Log("Press E to Interact.");
    }

    //open the elevator
    public void open()
    {
        //anim.SetTrigger("OpenDoor");
        anim.Play("ElevatorOpen");
       
        //door.SetActive(false);      
    }

    //close the elevator
    public void close()
    {
        //anim.Play("ElevatorClose");
       
        door.SetActive(true);
    }

    //pick up the key card
    public void pickUpKey()
    {
        keyCard.SetActive(false);
        hasKey = true;
        Inventory.instance.Add(keyCardItem);	// Add to inventory
    }

    //pick up the weapon
    public void pickUpWeapon()
    {
        weapon.SetActive(false);
        hasWeapon = true;
        Inventory.instance.Add(weaponItem);	// Add to inventory
    }

    //pick up the file
    public void pickUpFile()
    {
        file.SetActive(false);
        hasFile = true;
        Inventory.instance.Add(fileItem);	// Add to inventory
    }

    public void playPiano()
    {
        audio = audio.GetComponent<AudioSource>();
        isPiano = true;

        //make a random number to choose which song plays
        int randomNum = UnityEngine.Random.Range(0,4);
        Debug.Log(randomNum);

        //make a switch statement to play the song corresponding to the random number
        switch (randomNum)
        {
            case 1:
                Debug.Log("Playing Beauty");
                audio.clip = Beauty;
                break;
            case 2:
                Debug.Log("Playing Cloud Chamber");
                audio.clip = CloudChamber;
                break;
            case 3:
                Debug.Log("Playing Strange Dream");
                audio.clip = StrangeDream;
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }

}
