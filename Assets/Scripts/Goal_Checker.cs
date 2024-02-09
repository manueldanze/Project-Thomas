using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Checker : MonoBehaviour
{
    [SerializeField] Character_SO character_SO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.nameTag))
        {
            //collision.GetComponent<CharacterController>().enabled = true;
            print(character_SO.nameTag + " entered");
            character_SO.isInGoal = true;
            //collision.GetComponent<CharacterController>().enabled = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.nameTag))
        {
            //collision.GetComponent<CharacterController>().enabled = true;
            print(character_SO.nameTag + " exited");
            character_SO.isInGoal = false;
            //collision.GetComponent<CharacterController>().enabled = false;
        }
    }
}
