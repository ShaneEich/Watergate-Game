using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {
    public GameObject player;
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        //Debug.Log("Testing");
        if (CanSeePlayer(player))
        {
            mesh.material.color = Color.red;
        }
        else
        {
            mesh.material.color = Color.blue;
        }
    }

    bool CanSeePlayer(GameObject target)
    {
        //float heightOfPlayer = 1.5f;

        Vector3 startVec = transform.position;
        //startVec.y += heightOfPlayer;
        Vector3 startVecFwd = transform.forward;
        //startVecFwd.y += heightOfPlayer;

        RaycastHit hit;
        Vector3 rayDirection = target.transform.position - startVec;
        Debug.DrawRay(startVec, rayDirection, Color.yellow);
        // If the ObjectToSee is close to this object and is in front of it, then return true
        if ((Vector3.Angle(rayDirection, startVec)) < 30 &&
            (Vector3.Distance(startVec, target.transform.position) <= 20f))
        {
            //Debug.Log("close");
            return true;
        }
        if ((Vector3.Angle(rayDirection, startVecFwd)) < 30 &&
            Physics.Raycast(startVec, rayDirection, out hit, 5f))
        { // Detect if player is within the field of view

            if (hit.collider.gameObject == target)
            {
                Debug.Log("Can see player");
                return true;
            }
            else
            {
                Debug.Log("Can not see player");
                return false;
            }
        }
        return false;
    }
}
