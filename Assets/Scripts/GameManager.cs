using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputAction switchCharacter;

    [SerializeField] private GameObject thomas;
    [SerializeField] private GameObject chris;
    [SerializeField] private GameObject clair;

    private bool thomasIsActiveChar;
    private bool chrisIsActiveChar;
    private bool clairIsActiveChar;

    private bool isThomasInGoal = false;
    private bool isChrisInGoal = false;
    private bool isClairInGoal = false;

    private GameObject activeCharacter;


    private void OnEnable()
    {
        switchCharacter.Enable();
    }

    private void OnDisable()
    {
        switchCharacter.Disable();
    }


    private void Awake()
    {        
        thomasIsActiveChar = true;
        chris.gameObject.GetComponent<PlayerController>().enabled = false;
        clair.gameObject.GetComponent<PlayerController>().enabled = false;
        activeCharacter = thomas;
    }

    private void Update()
    {
        if (switchCharacter.triggered)
        {
            SwitchCharacter();
            SetActiveCharacter();
        }

        if (isThomasInGoal && isChrisInGoal && isClairInGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        else
        {
            thomasIsActiveChar = true;
            clairIsActiveChar = false;
            chrisIsActiveChar = false;
            thomas.GetComponent<PlayerController>().enabled = true;
            clair.GetComponent<PlayerController>().enabled = false;
            chris.GetComponent<PlayerController>().enabled = false;
        }
    }
    public GameObject GetActiveCharacter()
    {
        return activeCharacter;
    }

    public void SetIsThomasInGoal(bool value)
    {
        isThomasInGoal = value;
    }
    public void SetIsChrisInGoal(bool value)
    {
        isChrisInGoal = value;
    }
    public void SetIsClairInGoal(bool value)
    {
        isClairInGoal = value;
    }
}
