using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public Transform player;
	public float speed = 10f;
	public float rotateSpeed = 10f;

	private Vector3 movement;
	private float rotation;

	void Update ()
	{

        //movement.x = player.transform.position.x - transform.position.x;
        //movement.z = player.transform.position.z - transform.position.z;
        movement.z = Input.GetAxis("Vertical")*.5f;
        movement.x = Input.GetAxis("Horizontal")*.5f;
        movement.y = 0;
        rotation = Input.GetAxis("Mouse X")* rotateSpeed;
        
	}

	void FixedUpdate ()
	{
		transform.Translate(movement, Space.World);
		transform.Rotate(0f, 0f, rotation);
	}
	
}
