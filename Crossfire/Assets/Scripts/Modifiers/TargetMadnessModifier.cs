using UnityEngine;

public class TargetMadnessModifier : IModifier
{   
    public float Timeout {get;} = 15f;

    public TargetAffector targetAffector { get; } = TargetAffector.scene;
    
    public void Activate(GameObject collision)
    {
        SceneManager.Instance.targets.DestroyAllTargets();
        SceneManager.Instance.targets.targetLimit = 5;
        SceneManager.Instance.targets.InitialSpawn();
    }

    public void Deactivate()
    {
        SceneManager.Instance.targets.DestroyAllTargets();
        SceneManager.Instance.targets.targetLimit = 1;
        SceneManager.Instance.targets.InitialSpawn();
    }

}