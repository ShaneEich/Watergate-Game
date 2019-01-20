using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed;
    bool crouched;
    bool sprinting;


    public Collider topCollider;
    Rigidbody rb;
    Vector3 moveDirection;

    public new Camera camera;

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
        Crouch();
        Sprint();
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
    }

    void Crouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            if (!crouched)
            {
                topCollider.enabled = false;
                crouched = true;
                walkSpeed = walkSpeed / 2;
                //GameObject.Find("Main Camera").transform.position = new Vector3(0f,1f,0f);
                Debug.Log("Crouching");
            }
            else if (crouched)
            {
                topCollider.enabled = true;
                crouched = false;
                walkSpeed = walkSpeed * 2;
                
                Debug.Log("Standing");
            }
        }
    }
    void Sprint()
    {
        if (Input.GetButtonDown("Sprint") && !crouched)
        {
            if (!sprinting)
            {
                walkSpeed = walkSpeed * 2;
                sprinting = true;
                Debug.Log("Sprinting");
            }
            else if (sprinting)
            {
                walkSpeed = walkSpeed / 2;
                sprinting = false;
                Debug.Log("Walking");
            }
        }
    }
    void Move()
    {
        if (!crouched)
        {
            rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        }
        else if (crouched)
        {
            rb.velocity = moveDirection * walkSpeed * Time.deltaTime / 2;
        }
    }
    void FixedUpdate()
    {   
        Move();
    }
}
