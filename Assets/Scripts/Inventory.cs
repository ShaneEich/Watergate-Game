using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool currentState = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        OpenOrClose(currentState);
    }

    //method to set the inventory GUI to active by preessing 'I'
    public void Open()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(true);
        }
    }

    //method to set the inventory GUI to inactive by preessing 'I'
    public void Close()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(false);
        }
    }

    public void OpenOrClose(bool state)
    {
        state = !currentState;
        currentState = state;
        if (state == true)
        {
            Open();
        }
        if (state == false)
        {
            Close();
        }
    }
       
}
