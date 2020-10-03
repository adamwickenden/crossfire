using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Brain brain;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    bool human;
    [SerializeField]
    bool right;
    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    float slideSpeed = 10f;

    private float minAngle = -90f;
    private float maxAngle = 90f;

    public float minSlide = -1.5f;
    public float maxSlide = 1.5f;

    private float Angle { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (human)
        {
            UseHumanBrain();
        }
        else
        {
            UseAIBrain();
        }
        Angle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        brain.Tick();
    }

    public void UseHumanBrain()
    {
        brain = new HumanBrain(Player, rotationSpeed, slideSpeed, minAngle, maxAngle, minSlide, maxSlide, Angle, right);
    }

    public void UseAIBrain()
    {
        brain = new AIBrain(Player, rotationSpeed, slideSpeed, minAngle, maxAngle, minSlide, maxSlide, Angle);
    }
}
