using UnityEngine;
using System.Collections.Generic;

public interface IWeapon
{
    // Fire method, instantiates a game object, from the given position in the given direction
    List<GameObject> Fire(Vector3 position, Vector3 direction, float bulletScale);
    // Getter that returns the bullets fired per shot
    int GetBulletsPerShot();
    // Getter that returns the total bullets available for weapon
    int GetTotalBullets();
    // Getter that returns the goal scaling factor of bullets
    float GetGoalScaleFactor();
}