using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
    public GameObject dialogsys;
    private bool triggeredAlready = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !triggeredAlready)
        {
            dialogsys.SetActive(true);
        }
    }
}
