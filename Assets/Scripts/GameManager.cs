using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //// Params

    private PlayerInput input;

    private GameObject activeCharacter;

    private List<GameObject> characterList = new List<GameObject>();

    private int activeIndex = 0;

    //// Monobehavior

    private void Awake()
    {
        input = GameObject.FindWithTag("InputPackage").GetComponent<PlayerInput>();
        CreateCharacterList();
        Set_ActiveCharacter(0);
    }

    private void Update()
    {
        Update_ActiveCharacter();

        Check_WinCondition();
    }

    //// Custom Functions
    private void CreateCharacterList()
    {
        GameObject[] characterArr = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characterArr)
        {
            character.tag = character.GetComponent<CharacterController>().Get_NameTag();
            characterList.Add(character);
        }
    }

    private void Set_ActiveCharacter(int index)
    {
        foreach (GameObject character in characterList)
        {
            character.gameObject.GetComponent<CharacterController>().enabled = false;
        }
        characterList[index].gameObject.GetComponent<CharacterController>().enabled = true;
        activeCharacter = characterList[index];
    }

    private void Update_ActiveCharacter()
    {
        if (characterList.Count > 0)
        {     
            if (input.actions["Switch Character"].WasPressedThisFrame())
            {
                if (activeIndex == characterList.Count - 1)
                {
                    activeIndex = 0;

                    Set_ActiveCharacter(activeIndex);
                }
                else
                {
                    activeIndex++;

                    Set_ActiveCharacter(activeIndex);
                } 
            }
        }
        else
        {
            Debug.LogError("no characters placed in scene");
        }      
    }

    internal GameObject Get_activeCharacter()
    {
        return activeCharacter;
    }

    private void Check_WinCondition()
    {
        // hardcoded in lack of time, hard to write dynamic flexible code because of loose coupling of GameManager 

        if (characterList[0].GetComponent<CharacterController>().Get_IsInGoal() &&
            characterList[1].GetComponent<CharacterController>().Get_IsInGoal() &&
            characterList[2].GetComponent<CharacterController>().Get_IsInGoal())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
