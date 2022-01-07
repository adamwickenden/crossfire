using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScale : MonoBehaviour
{
    private float shrinkRate = 0.999f;

    private Vector3 baseScale = Vector3.one;

    private float minScale = 1.5f;
    private float maxScale = 4f;

    private void Start()
    {
        transform.localScale = baseScale;
    }

    private void Update()
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