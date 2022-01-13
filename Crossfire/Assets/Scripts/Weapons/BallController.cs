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
        if (collision.CompareTag("LeftGoal") | collision.CompareTag("RightGoal"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("PowerUp"))
        {
            // On collision witha power up; get and assign weapon, remove power up from list, destroy object
            parentManager.ChangeWeapon(collision.GetComponent<PowerUpController>().weapon);
            SceneManager.Instance.powerUps.RemovePowerUp(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    // Destroy on collision with wall, or main ball
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

        if (collision.gameObject.CompareTag("Target")){
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        parentManager.activeBullets.Remove(gameObject);
    }
}
