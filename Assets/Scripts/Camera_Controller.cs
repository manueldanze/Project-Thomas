using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private Camera mainCamera;
    private GameManager gameManager;

    [Range(0f, 5f)][SerializeField] private float camFollowSpeed;
    [Range(-10f, -100f)][SerializeField] private float camDistance;

    private void Awake()
    {
        mainCamera = Camera.main;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        FollowPlayerWithCamera(gameManager.GetActiveCharacter().GetComponent<Rigidbody2D>());
    }

    void FollowPlayerWithCamera(Rigidbody2D rb)
    {
        Vector3 playerPosition = rb.transform.position;

        Vector3 camPosition = mainCamera.transform.position;

        Vector3 newPosition = Vector3.Lerp(camPosition, playerPosition, camFollowSpeed * Time.deltaTime);

        mainCamera.transform.position = new Vector3(newPosition.x, newPosition.y, camDistance);
    }
}
