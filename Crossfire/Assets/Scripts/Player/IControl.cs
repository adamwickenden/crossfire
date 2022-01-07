using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IControl
{
    bool Fire();
    bool Shield();
    float Move();
    Vector3 Look();
    
    // Determines if the aim vector is world space or a unit direction vector
    bool AimType();
    
    // Call after firing a projectile to kill off the context
    void KillFire();
}
