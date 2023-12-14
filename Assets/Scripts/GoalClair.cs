using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalClair : MonoBehaviour
{
    [SerializeField] private GameManager_SO gameManagerSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Clair"))
        {
            gameManagerSO.isClairInGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Clair"))
        {
            gameManagerSO.isClairInGoal = false;
        }
    }
}
