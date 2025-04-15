using UnityEngine;

public class ModifierMadnessModifier : IModifier
{   
    public float Timeout {get;} = 10f;

    public TargetAffector targetAffector { get; } = TargetAffector.scene;
    
    public void Activate(GameObject collision)
    {
        SceneManager.Instance.modifiers.modifierCount = 8;
        SceneManager.Instance.modifiers.spawnChance = 1f;
    }

    public void Deactivate()
    {
        SceneManager.Instance.modifiers.DestroyVisibleModifiers();
        SceneManager.Instance.modifiers.modifierCount = 2;
        SceneManager.Instance.modifiers.spawnChance = 0.0005f;
    }

}