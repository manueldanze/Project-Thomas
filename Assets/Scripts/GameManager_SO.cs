using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager_SO", menuName = "ScriptableObjects/GameManager_SO", order = 1)]
public class GameManager_SO : ScriptableObject
{
    public Vector3 activeCharPosition;

    public bool isThomasInGoal = false;
    public bool isChrisInGoal = false;
    public bool isClairInGoal = false;
}
