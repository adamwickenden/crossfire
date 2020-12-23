using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class MouseKeyboard: IController
{
    private Mouse mouse;
    private Keyboard keyboard;

    public MouseKeyboard(Mouse m = null, Keyboard ky = null)
    {
        if (m != null & ky != null)
        {
            mouse = m;
            keyboard = ky;
        }
        else
        {
            mouse = Mouse.current;
            keyboard = Keyboard.current;
        }
    }

    public Vector3 AimDirection()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        worldPos = worldPos.normalized;
        return worldPos;
    }

    public Vector3 SlideDirection()
    {
        if (keyboard.aKey.isPressed & keyboard.dKey.isPressed)
        {
            return Vector3.zero;
        }
        else if (keyboard.aKey.isPressed)
        {
            return new Vector3(0f, 1f, 0f);
        }
        else if (keyboard.dKey.isPressed)
        {
            return new Vector3(0f, -1f, 0f);
        }
        else
        {
            return Vector3.zero;
        }
    }

    public bool QuickFirePressed()
    {
        return mouse.leftButton.wasPressedThisFrame;
    }
}
