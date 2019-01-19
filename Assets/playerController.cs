using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitvity = 3f;


    private playerMotor motor;

     void Start()
    {
        motor = GetComponent<playerMotor>();
    }

     void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 Movehorizontal = transform.right * horizontalMovement; 
        Vector3 MoveVertical = transform.forward * verticalMovement;
       
        //Final movement vector
        Vector3 velocity = (Movehorizontal + MoveVertical).normalized * speed;

        motor.Move(velocity);

        //calculate rotation for turning around 
        float yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitvity;

        motor.Rotate(rotation);

        float xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRotation,0f, 0f) * lookSensitvity;

        motor.cameraRotate(cameraRotation);

    }
}
