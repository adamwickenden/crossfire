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
    [SerializeField]
    GameObject goal;
    [SerializeField]
    GameObject shield;

    private float minSlide;
    private float maxSlide;

    private Vector3 movement = Vector3.zero;
    private Vector3 aim = Vector3.zero;

    private float rotationSpeed = 10f;
    private float slideSpeed = 5f;
    private float aimSpeed = 10f;

    private string aimType;
    private string controllerScheme;
    private float objectDepth = 0f;

    private float minAngle = -90f;
    private float maxAngle = 90f;

    private float xBound = 8f;
    private float yBound = 5f;

    private WeaponManager weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        weaponManager = this.gameObject.AddComponent<WeaponManager>();
        weaponManager.goal = goal.GetComponent<GoalScale>();

        controllerScheme = gameObject.GetComponent<PlayerInput>().currentControlScheme;
        Debug.Log(controllerScheme);

        GetMoveLimits();
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveLimits();
        Move();
        Aim();
        Rotate();
    }


    // Action Monitors 

    public void MonitorFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            weaponManager.Fire(player.transform.position, player.transform.right);
        }
    }

    public void MonitorMove(InputAction.CallbackContext ctx)
    {
        float y = Mathf.Clamp(ctx.ReadValue<float>(), minSlide, maxSlide);
        if (controllerScheme == "Keyboard&Mouse")
        {
            movement.y = IsRight() ? y : -y;
        }
        else
        {
            movement.y = y;
        }


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

    public void MonitorShield(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            shield.SetActive(true);
            weaponManager.canFire = false;
        }
        if (ctx.canceled)
        {
            shield.SetActive(false);
            weaponManager.canFire = true;
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


    private void Aim()
    {
        if (aimType == "position")
        {
            aim.x = Mathf.Clamp(aim.x, -xBound, xBound);
            aim.y = Mathf.Clamp(aim.y, -yBound, yBound);

            reticle.transform.position = aim;
            //reticle.transform.localPosition = aim;
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

        reticle.transform.rotation = Quaternion.identity;

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

    private void GetMoveLimits()
    {
        BoxCollider2D goalCollider = goal.GetComponent<BoxCollider2D>();

        minSlide = goalCollider.transform.position.y - (goalCollider.bounds.size.y / 2);
        maxSlide = goalCollider.transform.position.y + (goalCollider.bounds.size.y / 2);
    }
}
