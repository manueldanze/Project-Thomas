using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalThomas : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Thomas"))
        {
            Debug.Log("thomas enter");
            gameManager.SetIsThomasInGoal(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Thomas"))
        {
            Debug.Log("thomas exit");
            gameManager.SetIsThomasInGoal(false);
        }
    }
}
