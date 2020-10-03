using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : Brain
{
    public AIBrain(GameObject playerObject, float rotationSpeed, float slideSpeed, float minAngle, float maxAngle, float minSlide, float maxSlide, float Angle) : base(playerObject, rotationSpeed, slideSpeed, minAngle, maxAngle, minSlide, maxSlide, Angle)
    {

    }

    // Start is called before the first frame update
    public override void Tick()
    {
        aim();
        slide();
    }

    public void aim()
    {

    }

    public void slide()
    {

        float v = Mathf.Sin(Time.time * 5) * 3;

        Vector3 tempVect = new Vector3(0f, v, 0f);
        tempVect = tempVect.normalized * slideSpeed * Time.deltaTime;

        Vector3 currentPosition = playerObject.transform.position;
        currentPosition += tempVect;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minSlide, maxSlide);

        playerObject.transform.position = currentPosition;
    }
}
