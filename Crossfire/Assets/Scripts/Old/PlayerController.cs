using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public IBrain brain { get; private set; }

    [SerializeField]
    GameObject player;
    [SerializeField]
    bool human;
    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    float slideSpeed = 10f;

    public float minAngle = -90f;
    public float maxAngle = 90f;

    private float minSlide = -1.5f;
    private float maxSlide = 1.5f;

    private Gamepad gamepad;

    private MouseKeyboard con;


    // Start is called before the first frame update
    void Start()
    {
        //if (human)
        //{
        //    UseHumanBrain();
        //}
        //else
        //{
        //    UseAIBrain();
        //}
        con = new MouseKeyboard();
        UseHumanBrain();
        Debug.Log(con);
    }


    // Update is called once per frame
    void Update()
    {
        Aim();
        Slide();
        QuickFire();
    }


    public void UseHumanBrain()
    {
        brain = new HumanBrain(player, con);
    }


    //public void UseAIBrain()
    //{
    //    brain = new AIBrain(Player, rotationSpeed, slideSpeed, minAngle, maxAngle, minSlide, maxSlide, Angle);
    //}


    private void Aim()
    {
        float angle = brain.Aim();

        angle = ClampNotStupid(angle, minAngle, maxAngle);

        Quaternion q = Quaternion.Euler(0f, 0f, angle);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, q, Time.deltaTime * rotationSpeed);
    }


    private void Slide()
    {
        var tempVect = brain.Slide();

        tempVect = tempVect.normalized * slideSpeed * Time.deltaTime;

        Vector3 currentPosition = player.transform.position;
        currentPosition += tempVect;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minSlide, maxSlide);

        player.transform.position = currentPosition;
    }


    private void QuickFire()
    {
        bool shoot = brain.QuickFire();

        if (shoot)
        {
            Debug.Log("Pressed Left MB");
            GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
            Vector3 spawn_pos = player.transform.position + player.transform.right * 0.5f;
            GameObject ball = GameObject.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

            Vector3 velocity = player.transform.right * 10f;
            ball.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }


    private float ClampNotStupid(float angle, float min, float max)
    {
        if (brain.IsRight())
        {
            if (angle < max && angle >= 0) return 90f;
            if (angle > min && angle < 0) return -90f;
        }
        else
        {
            if (angle > max && angle >= 0) return 90f;
            if (angle < min && angle < 0) return -90f;
        }
        return angle;
    }
}
