using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<CharacterController>().Set_IsGrounded(true);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponentInParent<CharacterController>().Set_IsGrounded(false);
    }
}
