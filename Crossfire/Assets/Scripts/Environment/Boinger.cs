using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boinger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target") | collision.CompareTag("Ball"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 raidalDirection = collision.transform.position - transform.position;

            rb.AddForce(raidalDirection, ForceMode2D.Impulse);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Target") | collision.CompareTag("Ball"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 raidalDirection = collision.transform.position - transform.position;

            rb.AddForce(raidalDirection, ForceMode2D.Impulse);

        }
    }
}
