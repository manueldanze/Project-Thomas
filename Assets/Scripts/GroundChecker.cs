using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<PlayerController>().SetIsGrounded(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<PlayerController>().SetIsGrounded(false);
    }
}
