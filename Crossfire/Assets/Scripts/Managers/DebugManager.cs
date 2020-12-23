using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public Text playerLeftDebug;
    public Text playerRightDebug;

    public Text playerLeftDebug2;
    public Text playerRightDebug2;

    private NewPlayerController playerLeft;
    private NewPlayerController playerRight;

    public static DebugManager Instance { get; private set; } // static singleton

    void Start()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        playerLeftDebug = GameObject.Find("PlayerLeftDebug").GetComponent<Text>();
        playerRightDebug = GameObject.Find("PlayerRightDebug").GetComponent<Text>();

        playerLeftDebug2 = GameObject.Find("PlayerLeftDebug2").GetComponent<Text>();
        playerRightDebug2 = GameObject.Find("PlayerRightDebug2").GetComponent<Text>();

        playerLeft = SceneManager.Instance.playerLeft.GetComponentInChildren<NewPlayerController>();
        playerRight = SceneManager.Instance.playerRight.GetComponentInChildren<NewPlayerController>();
    }

    private void Update()
    {
        playerLeftDebug.text = "P1 SCORE: " + SceneManager.Instance.score.playerLeftScore.ToString();
        //playerLeftDebug2.text = "local pos P1: " + playerLeft.transform.localPosition.ToString();
        playerRightDebug.text = "P2 SCORE: " + SceneManager.Instance.score.playerRightScore.ToString();
        //playerRightDebug2.text = "local Position R-P1 " + playerLeft.transform.GetChild(0).transform.localPosition;
    }
}
