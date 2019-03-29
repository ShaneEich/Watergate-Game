using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //set inventory GUI to inactive
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //set inventory GUI to active
            gameObject.SetActive(true);
        }
    }
}
