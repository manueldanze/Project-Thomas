using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputAction switchCharacter;

    [SerializeField] private GameObject thomas;
    [SerializeField] private GameObject chris;
    [SerializeField] private GameObject clair;

    private bool thomasIsActive;
    private bool chrisIsActive;
    private bool clairIsActive;

    public GameObject activeCharacter;


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
        thomasIsActive = true;
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
    }

    private void SetActiveCharacter()
    {
        if (thomasIsActive)
        {
            activeCharacter = thomas;
        }
        else if (chrisIsActive) 
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
        if (thomasIsActive)
        {
            chrisIsActive = true;
            thomasIsActive = false;
            clairIsActive = false;
            chris.GetComponent<PlayerController>().enabled = true;
            thomas.GetComponent<PlayerController>().enabled = false;
            clair.GetComponent<PlayerController>().enabled = false;
        }
        else if (chrisIsActive)
        {
            clairIsActive = true;
            chrisIsActive = false;
            thomasIsActive = false;
            clair.GetComponent<PlayerController>().enabled = true;
            chris.GetComponent<PlayerController>().enabled = false;
            thomas.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            thomasIsActive = true;
            clairIsActive = false;
            chrisIsActive = false;
            thomas.GetComponent<PlayerController>().enabled = true;
            clair.GetComponent<PlayerController>().enabled = false;
            chris.GetComponent<PlayerController>().enabled = false;
        }
    }
    public GameObject GetActiveCharacter()
    {
        return activeCharacter;
    }
}
