using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Rigidbody2D parent;

    private void Awake()
    {
        parent = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parent.GetComponent<PlayerController>().SetIsGrounded(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.GetComponent<PlayerController>().SetIsGrounded(false);
    }
}
