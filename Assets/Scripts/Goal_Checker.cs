using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal_Checker : MonoBehaviour
{
    [SerializeField] Character_SO character_SO;

    [SerializeField] TextMeshProUGUI displayDebugConsole; // debug purpose of OnTrigger2D events for android build

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.nameTag))
        {
            // displayDebugConsole.text = character_SO.nameTag + " entered goal";
            character_SO.isInGoal = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.nameTag))
        {
            // displayDebugConsole.text = character_SO.nameTag + " exited goal";
            character_SO.isInGoal = false;
        }
    }
}
