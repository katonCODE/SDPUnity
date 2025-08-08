using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    //called once per frame

    void Update()
    {
        //use this for processing inputs
        ProcessInputs();
    }

    //called every fixed framerate frame if monobehaviour is enabled

    void FixedUpdate()
    {
        //use this for physic calculations
        Move();

    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //gives either 1 or 0 when a horizontal key is pressed
        float moveY = Input.GetAxisRaw("Vertical"); //gives either 1 or 0 when vertical key is pressed
        //getAxisRaw is used over normal getAxis because movement is not required to be dynamic. Either the input registers as 1 or 0

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
