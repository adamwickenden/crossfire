using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScale : MonoBehaviour
{
    // Name change hack
    private float shrinkRate = 0.995f;

    private Vector3 baseScale = Vector3.one;

    private float minScale = 1.5f;
    private float maxScale = 3f;

    private void Start()
    {
        transform.localScale = baseScale;
    }

    private void FixedUpdate()
    {
        ScaleDown();
    }

    public void ScaleUp(float goalScaleFactor)
    {
        float newY = transform.localScale.y * goalScaleFactor;
        newY = Mathf.Clamp(newY, minScale, maxScale);

        transform.localScale = new Vector3(transform.localScale.x, newY, transform.localScale.z);
    }


    private void ScaleDown()
    {
        float newY = transform.localScale.y * shrinkRate;
        newY = Mathf.Clamp(newY, minScale, maxScale);

        transform.localScale = new Vector3(transform.localScale.x, newY, transform.localScale.z);
    }

}