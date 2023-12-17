using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Rigidbody2D rb = collision.attachedRigidbody;
        CharacterController character = rb.GetComponent<CharacterController>();

        if (!character.Get_IsImmuneToHazards())
        {
            rb.velocity = Vector3.zero;
            rb.MovePosition(character.Get_SpawnPos());
        }
    }
}
