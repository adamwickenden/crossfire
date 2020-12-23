using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class HumanBrain : IBrain
{
    private IController currentController;
    private GameObject player;

    public HumanBrain(GameObject playerObject, IController controller)
    {
        currentController = controller;
        player = playerObject;

    }

    public float Aim()
    {
        Vector3 point = currentController.AimDirection();

        Vector3 dir = point - player.transform.position.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;

    }

    public Vector3 Slide()
    {
        return currentController.SlideDirection();
    }

    public bool QuickFire()
    {
        return currentController.QuickFirePressed();
    }

    public bool IsRight()
    {
        Vector3 reference = player.transform.position - SceneManager.Instance.board.transform.position;
        if (reference.x > 0) { return true; }
        else { return false; }
    }
}
