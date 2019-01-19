﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class playerMotor : MonoBehaviour {

    [SerializeField]
    private Camera Cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


   

    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void Rotate(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    public void cameraRotate(Vector3 cameraRotation)
    {
        this.cameraRotation = cameraRotation;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (Cam != null)
        {
            Cam.transform.Rotate(-cameraRotation);
        }
    }

    

}
