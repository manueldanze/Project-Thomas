using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character_SO", menuName = "ScriptableObjects/Character_SO", order = 1)]
public class Character_SO : ScriptableObject
{
    // not visible 
    internal string nameTag; // for winning condition check
    internal bool isActive;
    internal GameObject gameObj; 

    public bool isImmuneToHazards;

    public bool isInGoal;

    public Vector3 position;
    
    public float mass;
    public float maxVelocityX;
    public float maxVelocityY;
    public float moveSpeed;
    public float jumpMagnitude;
}
