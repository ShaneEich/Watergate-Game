﻿using System.Collections;
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

    //create game objects used in this script
    public GameObject Player;
    public GameObject door;
    public GameObject keyCard;
    public GameObject weapon;
    public GameObject file;
    Animator anim;

    public Canvas noteCanvas;
    public GameObject note;
    public TextMeshProUGUI noteText;

    private void Start()
    {

        anim = GetComponent<Animator>();
    }
    public void CanInteract()
    {
        Debug.Log("Press E to Interact.");
    }

    //open the elevator
    public void open()
    {
        anim.SetTrigger("OpenDoor");
        //door.SetActive(false);      
    }

    //close the elevator
    public void close()
    {
        door.SetActive(true);
    }

    //pick up the key card
    public void pickUpKey()
    {
        keyCard.SetActive(false);
        hasKey = true;
    }

    //pick up the weapon
    public void pickUpWeapon()
    {
        weapon.SetActive(false);
        hasWeapon = true;
    }

    //pick up the file
    public void pickUpFile()
    {
        file.SetActive(false);
        hasFile = true;
    }

    public void viewItem()
    {
        noteCanvas.enabled = true;
    }
}
