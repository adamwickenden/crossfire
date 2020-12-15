using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public Text playerLeftDebug;
    public Text playerRightDebug;

    private PlayerController playerLeft;
    private PlayerController playerRight;

    public static DebugManager Instance { get; private set; } // static singleton

    void Start()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        playerLeftDebug = GameObject.Find("PlayerLeftDebug").GetComponent<Text>();
        playerRightDebug = GameObject.Find("PlayerRightDebug").GetComponent<Text>();

        playerLeft = SceneManager.Instance.playerLeft.GetComponent<PlayerController>();
        playerRight = SceneManager.Instance.playerRight.GetComponent<PlayerController>();
    }

    private void Update()
    {
        playerLeftDebug.text = playerLeft.brain.Angle.ToString();
        playerRightDebug.text = playerRight.brain.Angle.ToString();
    }
}
