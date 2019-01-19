using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDistance = 1.0f;
    public int currentPoint = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(path[currentPoint].position, transform.position);

        transform.position = Vector3.Lerp(transform.position, path[currentPoint].position, Time.deltaTime * speed);

        if (distance < reachDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    public void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDistance);
                }
            }
        }
    }
}
