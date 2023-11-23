using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction move;

    [SerializeField] private float maxVelocityX;
    [SerializeField] private float maxVelocityY;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpMagnitude;

    private bool isJumping;


    private Rigidbody2D rb;

    private void OnEnable()
    {
        jump.Enable();
        move.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
        move.Disable();
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // control jump feedback with this params
        rb.mass = 1;
        rb.gravityScale = 2;
        jumpMagnitude = 15;       
        moveSpeed = 5;    
        
        maxVelocityX = 15;  
        maxVelocityY = 15;
    }

    private void FixedUpdate()
    {
        // check how this works
    }

    void Update()
    {
        if (rb.velocity.y != 0)
        {
            isJumping = true;

        }
        else
        {
            isJumping = false;
        }

        // jump
        if (!isJumping && jump.triggered)
        {
            rb.AddForce(jumpMagnitude * jump.ReadValue<Vector2>(), ForceMode2D.Impulse);
        }

        // move
        rb.AddForce(moveSpeed * move.ReadValue<Vector2>(), ForceMode2D.Force);


        // cap velocity
        if (rb.velocity.magnitude > maxVelocityX)
        {
            rb.velocity = new Vector2(Vector2.ClampMagnitude(rb.velocity, maxVelocityX).x, rb.velocity.y);
        }

        if (rb.velocity.y < 0 && rb.velocity.magnitude > maxVelocityY)
        {
            rb.velocity = new Vector2(Vector2.ClampMagnitude(rb.velocity, maxVelocityX).x,
                Vector2.ClampMagnitude(rb.velocity, maxVelocityY).y);
        }

    }


}
