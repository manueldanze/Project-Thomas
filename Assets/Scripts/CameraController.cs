using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameManager_SO gameManager_SO;

    [Range(0f, 5f)]
    [SerializeField] private float camFollowSpeed;

    [Range(-10f, -100f)]
    [SerializeField] private float camDistance;

    private void FixedUpdate()
    {
        FollowPlayerWithCamera(gameManager_SO.activeCharPosition);            
    }

    private void FollowPlayerWithCamera(Vector3 playerPosition)
    {
        Vector3 newPosition = Vector3.Lerp(Camera.main.transform.position, playerPosition, camFollowSpeed * Time.fixedDeltaTime);

        Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, camDistance);
    }
}
