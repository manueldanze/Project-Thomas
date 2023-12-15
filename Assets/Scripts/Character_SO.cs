using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character_SO", menuName = "ScriptableObjects/Character_SO", order = 1)]
public class Character_SO : ScriptableObject
{
    internal string NAMETAG; //not visible
    public bool isInGoal;
    public bool isActive;
    public Vector3 position;
    
    public float mass;
    public float maxVelocityX;
    public float maxVelocityY;
    public float moveSpeed;
    public float jumpMagnitude;
}
