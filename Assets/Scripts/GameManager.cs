using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputAction switchCharacter;

    private GameObject activeCharacter;

    [SerializeField] private GameObject thomas;
    [SerializeField] private GameObject chris;
    [SerializeField] private GameObject clair;

    [SerializeField] private GameManager_SO gameManager_SO;

    private bool thomasIsActiveChar = true;
    private bool chrisIsActiveChar = false;
    private bool clairIsActiveChar = false;


    private void Awake()
    {        
        chris.gameObject.GetComponent<PlayerController>().enabled = false;
        clair.gameObject.GetComponent<PlayerController>().enabled = false;

        activeCharacter = thomas;

        UpdateGameManager_SO();
    }

    private void Update()
    {
        UpdateActiveCharacter();
        UpdateGameManager_SO();
        CheckWinCondition();
    }



    private void OnEnable()
    {
        switchCharacter.Enable();
    }

    private void OnDisable()
    {
        switchCharacter.Disable();
    }

    private void UpdateActiveCharacter()
    {
        if (switchCharacter.triggered)
        {
            SwitchCharacter();
            SetActiveCharacter();
        }
    }

    private void SwitchCharacter()
    {
        if (thomasIsActiveChar)
        {
            chrisIsActiveChar = true;
            thomasIsActiveChar = false;
            clairIsActiveChar = false;
            chris.GetComponent<PlayerController>().enabled = true;
            thomas.GetComponent<PlayerController>().enabled = false;
            clair.GetComponent<PlayerController>().enabled = false;
        }
        else if (chrisIsActiveChar)
        {
            clairIsActiveChar = true;
            chrisIsActiveChar = false;
            thomasIsActiveChar = false;
            clair.GetComponent<PlayerController>().enabled = true;
            chris.GetComponent<PlayerController>().enabled = false;
            thomas.GetComponent<PlayerController>().enabled = false;
        }
        else if(clairIsActiveChar)
        {
            thomasIsActiveChar = true;
            clairIsActiveChar = false;
            chrisIsActiveChar = false;
            thomas.GetComponent<PlayerController>().enabled = true;
            clair.GetComponent<PlayerController>().enabled = false;
            chris.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void SetActiveCharacter()
    {
        if (thomasIsActiveChar)
        {
            activeCharacter = thomas;
        }
        else if (chrisIsActiveChar)
        {
            activeCharacter = chris;
        }
        else
        {
            activeCharacter = clair;
        }
    }

    private void UpdateGameManager_SO()
    {
        gameManager_SO.activeCharPosition = activeCharacter.transform.position;
    }

    private void CheckWinCondition()
    {
        if (gameManager_SO.isThomasInGoal && gameManager_SO.isChrisInGoal && gameManager_SO.isClairInGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
