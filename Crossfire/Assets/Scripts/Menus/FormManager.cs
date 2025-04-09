using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

public class FormManager : MonoBehaviour
{
	[SerializeField]
	public GameObject control;
	[SerializeField]
	public GameObject input;

	private Dropdown controlDropdown;
	private Dropdown inputDropdown;

	private int controllerCountCache = 0;

	public void Awake()
	{
		controlDropdown = control.GetComponent<Dropdown>();
		inputDropdown = input.GetComponent<Dropdown>();

		SetControllerDropdownValues();
		controllerCountCache = Gamepad.all.Count();
	}
	
	public void Update()
	{
		SetControllerDropdownValues();
	}

	public void SetControllerDropdownValues() {
		if (controllerCountCache != Gamepad.all.Count())
		{
			if (InputSystem.devices.OfType<Gamepad>().Count() > 0) 
			{
				for (int i = 0; i < InputSystem.devices.OfType<Gamepad>().Count(); i++) 
				{
					var controllerName = new Dropdown.OptionData("Controller " + (i+1));
					
					if (!inputDropdown.options.Contains(controllerName))
					{
						Debug.Log(controllerName);
						Debug.Log(inputDropdown.options[0]);
						inputDropdown.options.Add(controllerName);
					}
				}
			}
			controllerCountCache = Gamepad.all.Count();
		}
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
