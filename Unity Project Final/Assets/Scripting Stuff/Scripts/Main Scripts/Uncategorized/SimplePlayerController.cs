using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // Variables for movement
    public float mouseSensitivity = 100f;
    public float speedF = 0.3f;
    public float speedB = 0.15f;

    public Transform playerBody;
    public CharacterController controller;

    // Variables for gravity
    public Vector3 velocity;
    public Vector3 velocityS;
    public float gravity = -9.81f;

    // Variables for jumping
    public float jumpHeight = 5f;
    public float charHeight = 1.2f;
    public bool isGrounded = false;

    // Audio

    // Update is called once per frame

    void Update()
    {
        ProcessRaycast();
        ProcessJumping();
    }

    private void FixedUpdate()
    {
        PlayerMover();
        ApplyGravity();
        ProcessRaycast();
        ProcessJumping();

        
    }

    void PlayerMover()  
    {
        float h = Input.GetAxis("Horizontal");              
        float v = Input.GetAxis("Vertical");              

        velocityS = new Vector3(0, 0, v);        
        velocityS = transform.TransformDirection(velocityS);

        if (v > 0.1)
        {
            velocityS *= speedF;     
        }
        else if (v < -0.1)
        {
            velocityS *= speedB;
        }

        controller.Move(velocityS);
        transform.Rotate(0, h * 2.5f, 0);
    }

    void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void ProcessJumping()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }
    }

    void ProcessRaycast()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red, charHeight);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), charHeight))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
