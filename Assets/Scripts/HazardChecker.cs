using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardChecker : MonoBehaviour
{
    GameManager_SO gameManager_SO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.attachedRigidbody.MovePosition(gameManager_SO.spawn);
    }
}
