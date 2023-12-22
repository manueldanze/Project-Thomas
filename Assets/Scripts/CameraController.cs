using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameManager gameManager;

    [Range(0f, 5f)]
    [SerializeField] private float camFollowSpeed;

    [Range(-10f, -100f)]
    [SerializeField] private float camDistance;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        FollowPlayerWithCamera(gameManager.Get_activeCharacter().transform.position);           
    }

    private void FollowPlayerWithCamera(Vector3 playerPosition)
    {
        Vector3 newPosition = Vector3.Lerp(Camera.main.transform.position, playerPosition, camFollowSpeed * Time.fixedDeltaTime);

        Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, camDistance);
    }
}
