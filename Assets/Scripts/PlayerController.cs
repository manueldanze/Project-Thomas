using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbThomas;
    private Rigidbody2D rbChris;
    private Rigidbody2D rbClair;

    private Camera mainCamera;

    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction move;
    [SerializeField] private InputAction switchCharacter;


    [Range(0f, 5f)] [SerializeField] private float camFollowSpeed;
    [Range(-10f, -100f)] [SerializeField] private float camDistance;
    [SerializeField] private float maxVelocityX;
    [SerializeField] private float maxVelocityY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpMagnitude;

    private bool isJumping;

    private bool thomasIsActive;
    private bool chrisIsActive;
    private bool clairIsActive;



    private void Awake()
    {
        mainCamera = Camera.main;

        rbThomas = GameObject.FindWithTag("Thomas").GetComponent<Rigidbody2D>();
        rbChris = GameObject.FindWithTag("Chris").GetComponent<Rigidbody2D>();
        rbClair = GameObject.FindWithTag("Clair").GetComponent<Rigidbody2D>();

        thomasIsActive = true;
        rbChris.GetComponent<PlayerController>().enabled = false;
        rbClair.GetComponent<PlayerController>().enabled = false;
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {

    }


    private void Update()
    {

        if (switchCharacter.triggered)
        {
            SwitchCharacter();
        }
            
        




        Rigidbody2D rb = GetActiveCharacterRB();
        JumpPlayer(rb);
        MovePlayer(rb);
        CapPlayerVelocity(rb);
        FollowPlayerWithCamera(rb);
    }

    private Rigidbody2D GetActiveCharacterRB()
    {
        if (clairIsActive)
        {
            return rbClair;
        }
        else if (chrisIsActive)
        {
            return rbChris;
        }
        else
        {
            return rbThomas;
        }
    }


    private void SwitchCharacter()
    {
        if (thomasIsActive)
        {
            chrisIsActive = true;
            thomasIsActive = false;
            clairIsActive = false;
            rbChris.GetComponent<PlayerController>().enabled = true;
            rbThomas.GetComponent<PlayerController>().enabled = false;
            rbClair.GetComponent<PlayerController>().enabled = false;       
        }
        else if (chrisIsActive)
        {
            clairIsActive = true;
            chrisIsActive = false;
            thomasIsActive = false;
            rbClair.GetComponent<PlayerController>().enabled = true;
            rbChris.GetComponent<PlayerController>().enabled = false;
            rbThomas.GetComponent<PlayerController>().enabled = false;          
        }
        else
        {
            thomasIsActive = true;
            clairIsActive = false;
            chrisIsActive = false;
            rbThomas.GetComponent<PlayerController>().enabled = true;
            rbClair.GetComponent<PlayerController>().enabled = false;
            rbChris.GetComponent<PlayerController>().enabled = false;      
        }
    }





    private void OnEnable()
    {
        jump.Enable();
        move.Enable();
        switchCharacter.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
        move.Disable();
        switchCharacter.Disable();
    }


    private void JumpPlayer(Rigidbody2D rb)
    {
        if (!isJumping && jump.triggered)
        {
            rb.AddForce(jumpMagnitude * jump.ReadValue<Vector2>(), ForceMode2D.Impulse);
        }
    }


    private void MovePlayer(Rigidbody2D rb)
    {
        rb.AddForce(moveSpeed * move.ReadValue<Vector2>(), ForceMode2D.Force);
    }


    private void CapPlayerVelocity(Rigidbody2D rb)
    {
        if (rb.velocity.y != 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

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


    void FollowPlayerWithCamera(Rigidbody2D rb)
    {
        Vector3 playerPosition = rb.transform.position;

        Vector3 camPosition = mainCamera.transform.position;
        
        // Adjust camera position smoothly to follow player
        Vector3 newPosition = Vector3.Lerp(camPosition, playerPosition, camFollowSpeed * Time.deltaTime);

        mainCamera.transform.position = new Vector3(newPosition.x, newPosition.y, camDistance);
    }


}
