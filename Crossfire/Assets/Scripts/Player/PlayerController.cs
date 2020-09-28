using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    float slideSpeed = 10f;

    private float minAngle = -90f;
    private float maxAngle = 90f;

    public float minSlide = -1.5f;
    public float maxSlide = 1.5f;

    private float Angle { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Angle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        aim();
        slide();
    }

    void aim()
    {
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = point - Player.transform.position;
        dir.Normalize();

        Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Angle = Mathf.Clamp(Angle, minAngle, maxAngle);

        Quaternion q = Quaternion.Euler(0f, 0f, Angle); 
        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    void slide()
    {
        float v = Input.GetAxis("Horizontal");

        Vector3 tempVect = new Vector3(0f, v, 0f);
        tempVect = tempVect.normalized * slideSpeed * Time.deltaTime;

        Vector3 currentPosition = Player.transform.position;
        currentPosition += tempVect;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minSlide, maxSlide);

        Player.transform.position = currentPosition;
    }
}
