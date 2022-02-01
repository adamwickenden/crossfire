using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{
    [SerializeField]
    public GameObject control;
    [SerializeField]
    public GameObject input;

    private Dropdown controlDropdown;
    private Dropdown inputDropdown;

    public void Awake()
    {
        controlDropdown = control.GetComponent<Dropdown>();
        inputDropdown = input.GetComponent<Dropdown>();
    }

    public void ControlHideInput()
    {
        // Control dropdown is: 0 = Player, 1 = AI
        // If control is AI, remove the input dropdown.
        if(controlDropdown.value == 1)
        {
            input.SetActive(false);
        }
        else { input.SetActive(true); }
    }
}
