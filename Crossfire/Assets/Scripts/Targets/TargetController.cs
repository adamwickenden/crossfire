using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Destroy on hit of goal, and call score.OnScore()
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.Instance.score.OnScore(collision.gameObject);
        SceneManager.Instance.targets.RemoveTarget(this.gameObject);

        Destroy(this.gameObject);
    }
}
