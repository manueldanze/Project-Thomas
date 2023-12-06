using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction move;

    [SerializeField] private float maxVelocityX;
    [SerializeField] private float maxVelocityY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpMagnitude;

    private bool isGrounded;

    private Vector2 moveForce;
    private Vector2 jumpForce;

    private float rbVelocityMagnitude;
    private Vector2 rbVelocity;

    private void Update()
    {
        moveForce = move.ReadValue<Vector2>();
        jumpForce = jump.ReadValue<Vector2>();

        rbVelocity = rb.velocity;
        rbVelocityMagnitude = rb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        Jump(rb);
        Move(rb);
        ClampCharacterVelocity(rb);
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


    private void Jump(Rigidbody2D rb)
    {
        if (isGrounded && jump.triggered)
        {
            rb.AddForce(jumpMagnitude * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }


    private void Move(Rigidbody2D rb)
    {
        rb.AddForce(moveSpeed * moveForce * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void ClampCharacterVelocity(Rigidbody2D rb)
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

    public void SetIsGrounded(bool value)
    {
        isGrounded = value;
    }
}
