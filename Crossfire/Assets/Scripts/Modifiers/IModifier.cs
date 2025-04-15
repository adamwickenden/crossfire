using UnityEngine;

public interface IModifier
{
    // Activate Method that does something when hit by ball, then Modifier is added to the player.
    void Activate(GameObject collision);
    // Reverse whatever affect has been applied;
    void Deactivate();
    // Return a timeout for the Modifier
    float Timeout { get; } 
    // What the modifier affects
    TargetAffector targetAffector { get; }
}

public enum TargetAffector
{
    player,
    scene
}