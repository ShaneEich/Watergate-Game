using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clue : MonoBehaviour
{
    public GameObject noteCanvas;
    public TextMeshProUGUI noteText;
    public string clueText;
    public bool onTrigger;


    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;      
    }

    private void OnTriggerExit(Collider other)
    {
        noteCanvas.SetActive(false);
        noteText.text = "";
        onTrigger = false;
    }



    public void OnGUI()
    {
        if (onTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to look at clue");

            if (Input.GetKeyDown(KeyCode.E))
            {
                noteText.text = clueText;
                noteCanvas.SetActive(true);
                onTrigger = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                noteText.text = "";
                noteCanvas.SetActive(false);
                onTrigger = false;
            }
        }
    }
}
