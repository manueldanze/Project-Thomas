using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private CharacterController cC;

    private void Start()
    {
        cC = GetComponentInParent<CharacterController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cC.Set_IsGrounded(true);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (cC == null) 
        {
            print("is null");
        }

        cC.Set_IsGrounded(false);
    }
}
