using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChris : MonoBehaviour
{
    [SerializeField] private GameManager_SO gameManagerSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Chris"))
        {
            gameManagerSO.isChrisInGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Chris"))
        {
            gameManagerSO.isChrisInGoal = false;
        }
    }
}
