using UnityEngine;

public class BallController : MonoBehaviour
{
    private int destroyTime = 10;

    // Destroy after 10 seconds
    private void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Destroy on hit of goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
