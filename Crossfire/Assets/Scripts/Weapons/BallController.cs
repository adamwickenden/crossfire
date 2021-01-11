using UnityEngine;

public class BallController : MonoBehaviour
{
    private int destroyTime = 5;

    private int bounces = 0;

    private int bounceLimit = 1;

    public WeaponManager parentManager;

    // Destroy after 10 seconds
    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    // Destroy on hit of goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Boinger"))
        {
            Destroy(gameObject);
        }
    }

    // Destroy on collision with wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (bounces < bounceLimit)
            {
                bounces++;
            }
            else if (bounces >= bounceLimit)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        parentManager.activeBullets.Remove(gameObject);
    }
}
