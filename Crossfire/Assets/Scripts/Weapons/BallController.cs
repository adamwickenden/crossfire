using System.Net;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private int destroyTime = 5;

    private int bounces = 0;

    private int bounceLimit = 1;

    public WeaponManager parentWeaponManager;

    public Player parentPlayer;

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
            parentWeaponManager.ChangeWeapon(collision.GetComponent<PowerUpController>().weapon);
            SceneManager.Instance.modifiers.RemoveModifier(collision.gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Modifier"))
        {
            // On collision with a modifier, remove the modifier from the list and destroy ball
            // The Modifiers OnTriggerEnter2D function should apply the modifier effect
            SceneManager.Instance.modifiers.RemoveModifier(collision.gameObject);
            // Set Modifier to invisible and un-collidable, we need to let the modifier destroy itself.
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
        parentWeaponManager.activeBullets.Remove(gameObject);
    }
}
