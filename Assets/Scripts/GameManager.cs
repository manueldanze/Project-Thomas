using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

//// Params

    [SerializeField] private InputAction switchCharacter;
    [SerializeField] private GameManager_SO gameManager_SO;

    private GameObject activeCharacter;

    private GameObject thomas;
    private GameObject chris;
    private GameObject clair;

    [SerializeField] private Character_SO character_SOThomas;
    [SerializeField] private Character_SO character_SOChris;
    [SerializeField] private Character_SO character_SOClair;


//// Monobehavior

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        thomas = character_SOThomas.gameObj;
        chris = character_SOChris.gameObj;
        clair = character_SOClair.gameObj;  

        // default start conditions
        chris.gameObject.GetComponent<CharacterController>().enabled = false;
        clair.gameObject.GetComponent<CharacterController>().enabled = false;
        character_SOThomas.isActive = true;
        activeCharacter = thomas;

        Update_GameManager_SO();
    }

    private void Update()
    {
        Update_ActiveCharacter();
        Update_GameManager_SO();
        Check_WinCondition();
    }

    private void OnEnable()
    {
        switchCharacter.Enable();
    }

    private void OnDisable()
    {
        switchCharacter.Disable();
    }


//// Custom Functions

    private void Update_ActiveCharacter()
    {
        if (switchCharacter.triggered)
        {
            Switch_Character();
            Set_ActiveCharacter();
        }
    }

    private void Switch_Character()
    {
        if (character_SOThomas.isActive)
        {
            character_SOChris.isActive = true;
            character_SOThomas.isActive = false;
            character_SOClair.isActive = false;
            chris.GetComponent<CharacterController>().enabled = true;
            thomas.GetComponent<CharacterController>().enabled = false;
            clair.GetComponent<CharacterController>().enabled = false;
        }
        else if (character_SOChris.isActive)
        {
            character_SOClair.isActive = true;
            character_SOChris.isActive = false;
            character_SOThomas.isActive = false;
            clair.GetComponent<CharacterController>().enabled = true;
            chris.GetComponent<CharacterController>().enabled = false;
            thomas.GetComponent<CharacterController>().enabled = false;
        }
        else if(character_SOClair.isActive)
        {
            character_SOThomas.isActive = true;
            character_SOClair.isActive = false;
            character_SOChris.isActive = false;
            thomas.GetComponent<CharacterController>().enabled = true;
            clair.GetComponent<CharacterController>().enabled = false;
            chris.GetComponent<CharacterController>().enabled = false;
        }
    }

    private void Set_ActiveCharacter()
    {
        if (character_SOThomas.isActive)
        {
            activeCharacter = thomas;
        }
        else if (character_SOChris.isActive)
        {
            activeCharacter = chris;
        }
        else
        {
            activeCharacter = clair;
        }
    }

    private void Update_GameManager_SO()
    {
        gameManager_SO.activeCharPosition = activeCharacter.transform.position;
    }

    private void Check_WinCondition()
    {
        if (character_SOThomas.isInGoal && character_SOChris.isInGoal && character_SOClair.isInGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
