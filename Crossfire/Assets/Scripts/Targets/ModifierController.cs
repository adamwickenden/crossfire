using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{

    public IModifier modifier {get; set;}

    private float startTime;

    private bool activated = false;

    private Player playerActivatedBy;
    
    private List<IModifier> modifiers = new List<IModifier>();

    void Awake(){
        modifiers.Add(new BallScaleModifier());
        modifiers.Add(new TargetMadnessModifier());
        modifiers.Add(new ModifierMadnessModifier());
    }

    // Start is called before the first frame update
    void Start()
    {
        modifier = modifiers[Random.Range(0, modifiers.Count)];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            startTime = Time.time;
            activated = true;
            modifier.Activate(collision.gameObject);
            if (modifier.targetAffector == TargetAffector.player)
            {
                playerActivatedBy = collision.GetComponentInParent<BallController>().parentPlayer;
                playerActivatedBy.activeModifier = modifier;
            }
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if ((Time.time > startTime + modifier.Timeout) & activated)
        {
            Debug.Log("Timeout passed, destroying");
            if (modifier.targetAffector == TargetAffector.player)
            {
                if (modifier == playerActivatedBy.activeModifier)
                {
                    modifier.Deactivate();
                }
            }
            else if (modifier.targetAffector == TargetAffector.scene)
            {
                modifier.Deactivate();
            }
            Destroy(gameObject);
        }
    }

}