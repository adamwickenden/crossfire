using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public int playerLeftScore = 0;
    public int playerRightScore = 0;

    public void OnScore(GameObject goal)
    {
        // Ball enters left = right goal, and vice versa
        if (goal.tag == "LeftGoal") { playerRightScore++; }
        if (goal.tag == "RightGoal") { playerLeftScore++; }
    }
}
