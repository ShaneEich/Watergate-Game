using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed;
    public Collider topCollider;
    Rigidbody rb;
    Vector3 moveDirection;
    bool crouched;
    // var camera = Camera.main;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        crouch();
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
    }

    void crouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            if (!crouched)
            {
                topCollider.enabled = false;
                crouched = true;
                walkSpeed = walkSpeed / 2;
            }else if (crouched)
            {
                topCollider.enabled = true;
                crouched = false;
                walkSpeed = walkSpeed * 2;
            }
        }
    }

    void Move()
    {
        if (!crouched)
        {
            rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        }else if (crouched)
        {
            rb.velocity = moveDirection * walkSpeed * Time.deltaTime / 2;
        }
    }

    void FixedUpdate()
    {
        
        Move();

    }
}
