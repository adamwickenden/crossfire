using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanControl : MonoBehaviour, IControl
{
    private bool fire = false;
    private float move = 0f;
    private Vector3 aim = Vector3.zero;
    private bool shield = false;
    private string aimType;

    // THIS IS OVERRIDING THE CONCEPT OF SUBSCRIBING TO ACTIONS, SO ITS CAUSING IT TO BE TRUE FOR >1 FRAME
    public void MonitorFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            fire = true;
        }
    }

    public void MonitorShield(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            shield = true;
        }
        if (ctx.canceled)
        {
            shield = false;
        }
    }

    public void MonitorMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<float>();
    }

    public void MonitorLook(InputAction.CallbackContext ctx)
    {
        aim = ctx.ReadValue<Vector2>();
        aimType = ctx.control.name;

        if (aimType == "position")
        {
            aim = Camera.main.ScreenToWorldPoint(aim);
            aim.z = 0f;
        }
    }

    public void MonitorPause(InputAction.CallbackContext ctx)
    {
        if (SceneManager.Instance.scoreCanvas.activeInHierarchy && !SceneManager.Instance.pauseCanvas.activeInHierarchy)
        {
            Time.timeScale = 0f;
            SceneManager.Instance.scoreCanvas.SetActive(false);
            SceneManager.Instance.pauseCanvas.SetActive(true);
        }
        else if (!SceneManager.Instance.scoreCanvas.activeInHierarchy && SceneManager.Instance.pauseCanvas.activeInHierarchy)
        {
            Time.timeScale = 1f;
            SceneManager.Instance.scoreCanvas.SetActive(true);
            SceneManager.Instance.pauseCanvas.SetActive(false);
        }
    }

    public bool Fire(){
        return fire;
    }
    public bool Shield(){
        return shield;
    }
    public float Move(){
        return move;
    }
    public Vector3 Look(){
        return aim;
    }
    public bool AimType(){
        if (aimType == "position"){
            return true;
        }
        else { return false; }
    }
    public void KillFire(){
        fire = false;
    }
}
