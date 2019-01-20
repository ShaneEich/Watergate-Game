using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour {
    public float lookRadius = 10f;
    Transform target;
    private NavMeshAgent agent;
    public Transform goal;
    public Transform[] points;
    private int destPoint = 0;
    int count = 0;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; // allows for continous movement from agent


        target = PlayerManager.instance.player.transform;
        
        
        GoToNextPoint();

    }
	
	// Update is called once per frame
	void Update () {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            
            // Move towards the target
            agent.SetDestination(target.position);

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                // Make sure to face towards the target
            }
        }
        
            
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        if (count <= destPoint){
            destPoint = (destPoint + 1) % points.Length;
            count++;

        }
        else
        {
            destPoint = 0;
            count = 0;
        }
        
        
            
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
