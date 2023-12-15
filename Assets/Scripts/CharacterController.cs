using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction move;

    [SerializeField] Character_SO character_SO;

    private Rigidbody2D rb;

    private float maxVelocityX;
    private float maxVelocityY;
    private float moveSpeed;
    private float jumpMagnitude;

    private Vector2 moveForce;
    private Vector2 jumpForce;
    private Vector2 rbVelocity;
    private float rbVelocityMagnitude;
  
    private bool isGrounded = false; // gets value from child "GroundChecker"

    private void Awake()
    {    
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Read_SOVariables();
        Read_Input();      
    }

    private void FixedUpdate()
    {
        Execute_Jump(rb);
        Execute_Move(rb);
        Clamp_Velocity(rb);
    }


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

    private void Read_SOVariables()
    {
        // put into Update() to update dynamic on runtime
        rb.mass = character_SO.mass;
        maxVelocityX = character_SO.maxVelocityX;
        maxVelocityY = character_SO.maxVelocityY;
        moveSpeed = character_SO.moveSpeed;
        jumpMagnitude = character_SO.jumpMagnitude;
        character_SO.NAMETAG = gameObject.tag;
    }

    private void Read_Input()
    {
        moveForce = move.ReadValue<Vector2>();
        jumpForce = jump.ReadValue<Vector2>();
        rbVelocity = rb.velocity;
        rbVelocityMagnitude = rb.velocity.magnitude;
    }

    private void Execute_Jump(Rigidbody2D rb)
    {
        if (isGrounded && jump.IsPressed())
        {
            rb.AddForce(jumpMagnitude * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void Execute_Move(Rigidbody2D rb)
    {
        rb.AddForce(moveSpeed * moveForce * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void Clamp_Velocity(Rigidbody2D rb)
    {
        if (rbVelocityMagnitude > maxVelocityX)
        {
            rb.velocity = new Vector2(Vector2.ClampMagnitude(rbVelocity, maxVelocityX).x, rbVelocity.y);
        }

        if (rbVelocity.y < 0 && rbVelocityMagnitude > maxVelocityY)
        {
            rb.velocity = new Vector2(Vector2.ClampMagnitude(rbVelocity, maxVelocityX).x,
                Vector2.ClampMagnitude(rbVelocity, maxVelocityY).y);
        }
    }

    public void Set_IsGrounded(bool value)
    {
        isGrounded = value;
    }
}
