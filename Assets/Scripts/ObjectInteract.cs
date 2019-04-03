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
    public bool hasClue;


    //create game objects used in this script
    public GameObject Player;
    public GameObject door;
    public GameObject keyCard;
    public GameObject weapon;
    public GameObject file;
    public Animator anim;
    private Item item;   // Item to put in the inventory if picked up


    private void Start()
    {
        anim = GetComponent<Animator>();
        
        Debug.Log("animation loaded");
    }
    public void CanInteract()
    {
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
        anim.Play("ElevatorClose");
       
        door.SetActive(true);
    }

    //pick up the key card
    public void pickUpKey()
    {
        keyCard.SetActive(false);
        hasKey = true;
        Inventory.instance.Add(this.item);	// Add to inventory
    }

    //pick up the weapon
    public void pickUpWeapon()
    {
        weapon.SetActive(false);
        hasWeapon = true;
        Inventory.instance.Add(this.item);	// Add to inventory
    }

    //pick up the file
    public void pickUpFile()
    {
        file.SetActive(false);
        hasFile = true;
        Inventory.instance.Add(this.item);	// Add to inventory
    }



}
