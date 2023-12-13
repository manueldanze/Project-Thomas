using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalClair : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Clair"))
        {
            Debug.Log("clair enter");
            gameManager.SetIsClairInGoal(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Clair"))
        {
            Debug.Log("clair exit");
            gameManager.SetIsClairInGoal(false);
        }
    }
}
