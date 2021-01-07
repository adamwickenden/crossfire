using UnityEngine;
using System.Collections;

public interface IWeapon
{
    // Fire method, instantiates a game object, from the given position in the given direction
    GameObject Fire(Vector3 position, Vector3 direction);

    // Getter that returns the total bullets available for weapon
    int GetTotalBullets();
    // Getter that returns the goal scaling factor of bullets
    float GetGoalScaleFactor();
}