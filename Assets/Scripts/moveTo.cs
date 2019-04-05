using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class moveTo : MonoBehaviour {

    public float fieldofViewAngle = 110f;
    public bool playerInSight;
    
    public float lookRadius = 10f;
    Transform target;
    private NavMeshAgent agent;
    public Transform Player;
    public Transform[] points;
    public ThirdPersonCharacter Enemy { get; private set; }
    private int destPoint = 0;
    int count = 0;
    Vector3 NP;

    // Use this for init ialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        Enemy = GetComponent<ThirdPersonCharacter>();
        agent.autoBraking = false; // allows for continous movement from agent
        //agent.updateRotation = false;
        //agent.updatePosition = true;
        target = PlayerManager.instance.Player.transform;
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
            Enemy.Move(agent.desiredVelocity, false, false);
            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //Enemy.Move(agent.velocity, false, false);
                // Make sure to face towards the target
            }
        }
        
            
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
            GoToNextPoint();
            //Enemy.Move(agent.desiredVelocity, false, false);
            Enemy.Move(NP, false, false);
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
            NP = agent.destination;
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
    /*
    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }
    */
}
