using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{

    public IModifier modifier {get; set;}

    private float startTime;
    
    private List<IModifier> modifiers = new List<IModifier>();

    void Awake(){
        modifiers.Add(new BallScaleModifier());
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
            modifier.Activate(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (Time.time > startTime + modifier.Timeout)
        {
            modifier.Deactivate();
        }
    }

}