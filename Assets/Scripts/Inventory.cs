using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool current = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenOrClose();
    }

    public void OpenOrClose()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(current);
            current = !current;
            //set inventory GUI to inactive/active by preessing 'I'
            gameObject.SetActive(current);
            Debug.Log(current);
        }
    }
}
