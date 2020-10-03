using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBrain : Brain
{
    private bool right;

    public HumanBrain(GameObject playerObject, float rotationSpeed, float slideSpeed, float minAngle, float maxAngle, float minSlide, float maxSlide, float Angle, bool right) : base(playerObject, rotationSpeed, slideSpeed, minAngle, maxAngle, minSlide, maxSlide, Angle)
    {
        this.right = right;
    }
    // Start is called before the first frame update
    public override void Tick()
    {
        aim();
        slide();
    }


    void aim()
    {
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = point - playerObject.transform.position;
        dir.Normalize();
        if (right)
        {
            dir = -dir;
        }

        Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Angle = Mathf.Clamp(Angle, minAngle, maxAngle);

        Quaternion q = Quaternion.Euler(0f, 0f, Angle);
        playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    void slide()
    {
        float v = Input.GetAxis("Horizontal");

        Vector3 tempVect = new Vector3(0f, v, 0f);
        tempVect = tempVect.normalized * slideSpeed * Time.deltaTime;

        Vector3 currentPosition = playerObject.transform.position;
        currentPosition += tempVect;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minSlide, maxSlide);

        playerObject.transform.position = currentPosition;
    }
}
