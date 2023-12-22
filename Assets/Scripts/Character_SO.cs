using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character_SO", menuName = "ScriptableObjects/Character_SO", order = 1)]
public class Character_SO : ScriptableObject
{
    internal GameObject gameObj;

    public string nameTag;

    public bool isImmuneToHazards;

    public bool isInGoal;
    
    public float mass;
    public float maxVelocityX;
    public float maxVelocityY;
    public float moveSpeed;
    public float jumpMagnitude;
}
