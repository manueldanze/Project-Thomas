using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
