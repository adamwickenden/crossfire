using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrain
{
    // Interface that defines the outputs of a Brain, Human or AI
    float Aim();
    Vector3 Slide();
    bool QuickFire();
    bool IsRight();
}
