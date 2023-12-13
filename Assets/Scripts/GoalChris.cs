using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChris : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Chris"))
        {
            Debug.Log("chris enter");
            gameManager.SetIsChrisInGoal(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Chris"))
        {
            Debug.Log("chris exit");
            gameManager.SetIsChrisInGoal(false);
        }
    }
}
