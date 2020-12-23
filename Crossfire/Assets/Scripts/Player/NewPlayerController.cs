using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class NewPlayerController : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject reticle;

    private float rotationSpeed = 10f;
    private float slideSpeed = 5f;
    private float aimSpeed = 10f;

    private string aimType;
    private float objectDepth = -2f;

    private float minAngle = -90f;
    private float maxAngle = 90f;

    private float minSlide = -1.8f;
    private float maxSlide = 1.5f;

    private float xBound = 8f;
    private float yBound = 5f;

    public Vector3 movement = Vector3.zero;
    public Vector3 aim = new Vector3(0f, 0f, -2f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Gamepad.current.name);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Aim();
        Rotate();
    }


    // Action Monitors 

    public void MonitorFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Fire();
        }
    }

    public void MonitorMove(InputAction.CallbackContext ctx)
    {
        float y = Mathf.Clamp(ctx.ReadValue<float>(), minSlide, maxSlide);
        movement.y = IsRight() ? y : -y;        
    }

    public void MonitorLook(InputAction.CallbackContext ctx)
    {
        aim = ctx.ReadValue<Vector2>();
        aimType = ctx.control.name;

        if (aimType == "position")
        {
            aim = Camera.main.ScreenToWorldPoint(aim);
            aim.z = objectDepth;
        }
    }

    // Update Helper Funtions

    private void Move()
    {
        var currPos = player.transform.position;

        currPos += movement * slideSpeed * Time.deltaTime;

        currPos.y = Mathf.Clamp(currPos.y, minSlide, maxSlide);

        player.transform.position = currPos;
    }

    private void Fire()
    {
        GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
        Vector3 spawn_pos = player.transform.position + player.transform.right * 0.5f;
        GameObject ball = GameObject.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

        Vector3 velocity = player.transform.right * 10f;
        ball.GetComponent<Rigidbody2D>().velocity = velocity;
    }


    private void Aim()
    {
        if (aimType == "position")
        {
            aim.x = Mathf.Clamp(aim.x, -xBound, xBound);
            aim.y = Mathf.Clamp(aim.y, -yBound, yBound);

            reticle.transform.position = aim;
        }
        else
        {
            Vector3 pos = reticle.transform.position;
            pos += aim * aimSpeed * Time.deltaTime;

            pos.x = Mathf.Clamp(pos.x, -xBound, xBound);
            pos.y = Mathf.Clamp(pos.y, -yBound, yBound);

            reticle.transform.position = pos;
        }
    }


    private void Rotate()
    {

        Vector3 dir = reticle.transform.position - player.transform.position;

        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        angle = ClampNotStupid(angle, minAngle, maxAngle);

        Quaternion q = Quaternion.Euler(0f, 0f, angle);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, q, Time.deltaTime * rotationSpeed);

    }

    // Helper Functions

    private float ClampNotStupid(float angle, float min, float max)
    {
        if (IsRight())
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

    public bool IsRight()
    {
        Vector3 reference = player.transform.position - SceneManager.Instance.board.transform.position;
        if (reference.x > 0) { return true; }
        else { return false; }
    }
}
