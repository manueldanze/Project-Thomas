using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

//// Params
    private PlayerInput input;

    [SerializeField] private Character_SO character_SO;

    // set initial spawn pos for possible reset of char when died
    private Vector3 spawnPos;
    
    private Rigidbody2D rb;

    // parameter config in Character_SO
    private float maxVelocityX;
    private float maxVelocityY;
    private float moveSpeed;
    private float jumpMagnitude;
    private bool isInGoal;

    // input buffer
    private Vector2 moveForce;
    private Vector2 jumpForce;
    private Vector2 rbVelocity;
    private float rbVelocityMagnitude;

    private string nameTag;

    // gets value from child "GroundChecker"
    private bool isGrounded = false;

    private bool isImmuneToHazards;

//// Monobehavior

    private void Awake()
    {
        input = GameObject.FindWithTag("InputPackage").GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        spawnPos = rb.transform.position;
        character_SO.gameObj = gameObject;
        nameTag = character_SO.nameTag;
    }


    private void Update()
    {
        Update_SOVariables();
        Read_Input();      
    }

    private void FixedUpdate()
    {
        Execute_Jump(rb);
        Execute_Move(rb);
        Clamp_Velocity(rb);
    }


//// Custom Functions

    private void Update_SOVariables()
    {
        rb.mass = character_SO.mass;
        maxVelocityX = character_SO.maxVelocityX;
        maxVelocityY = character_SO.maxVelocityY;
        moveSpeed = character_SO.moveSpeed;
        jumpMagnitude = character_SO.jumpMagnitude;
        isImmuneToHazards = character_SO.isImmuneToHazards;
        isInGoal = character_SO.isInGoal;
    }

        private void Read_Input()
    {
        moveForce = input.actions["move"].ReadValue<Vector2>();
        jumpForce = input.actions["jump"].ReadValue<Vector2>();
            
        rbVelocity = rb.velocity;
        rbVelocityMagnitude = rb.velocity.magnitude;
    }

    private void Execute_Jump(Rigidbody2D rb)
    {
        if (isGrounded && input.actions["jump"].IsPressed())
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

//// Getter & Setter
    public void Set_IsGrounded(bool value)
    {
        isGrounded = value;
    }

    public bool Get_IsImmuneToHazards()
    {
        return isImmuneToHazards;
    }
    public Vector3 Get_SpawnPos()
    {
        return spawnPos;
    }

    public string Get_NameTag()
    {
        return nameTag;
    }

    public bool Get_IsInGoal()
    {
        return isInGoal;
    }
}
