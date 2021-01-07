using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    private GameObject parent;

    private void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    // Destroy on hit of goal, and call score.OnScore()
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.Instance.score.OnScore(collision.gameObject);
        SceneManager.Instance.targets.RemoveTarget(parent);

        Destroy(parent);
    }
}
