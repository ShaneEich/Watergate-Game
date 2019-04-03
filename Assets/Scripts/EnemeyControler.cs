using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemeyControler : MonoBehaviour
{
    public float lookRadius = 10f; //radius around enemy AI 
    int count = 0;
    Transform target;
    Transform goal;
    // position of player
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); // sets agent to this gameobject navemesh
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.speed = 4f;
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                Debug.Log("Close to point");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                FaceTarget();
                Debug.Log("Go to next point");
            }
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            //FaceTarget();
            agent.speed = 3;
            GotoNextPoint();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

  


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius); // draws sphere around object acts as radius
    }

   

}
