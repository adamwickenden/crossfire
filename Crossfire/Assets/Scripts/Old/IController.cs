using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IController
{
    // Interface that defines the outputs of a Controller (mouse/keyboard, gamepad etc)
    // Normalised vector that defines the direction to aim towards
    Vector3 AimDirection();
    // Normalised vector that defines the direction to move
    Vector3 SlideDirection();
    // Boolean that state if QuickFie has been pressed
    bool QuickFirePressed();
}
