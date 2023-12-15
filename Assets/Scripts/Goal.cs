using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Character_SO character_SO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.NAMETAG))
        {            
            character_SO.isInGoal = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(character_SO.NAMETAG))
        {           
            character_SO.isInGoal = false;
        }
    }
}
