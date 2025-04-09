using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuState
{
	// All values initalised as -1, which indicates not set 
	// When control is AI, input should stay as -1

	// 0 = Player, 1 = AI
	public static int playerLeftControl = -1;
	// 0 = Keyboard, 1 = Gamepad
	public static int playerLeftInput = -1;

	public static int playerRightControl = -1;
	public static int playerRightInput = -1;
}