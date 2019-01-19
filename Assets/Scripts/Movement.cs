using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private bool facingRight = false;
    private float flip;

    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        UserInput();
        transform.Translate(direction * speed * Time.deltaTime);

        flip = Input.GetAxis("Horizontal");

        if (flip < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (flip > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    private void UserInput()
    {
        direction = Vector2.zero;

        //up inputs
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        //down inputs
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        //left inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        //right inputs
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}


    