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
        playerLeftDebug2.text = "P1 bullets: " + (playerLeft.GetComponent<WeaponManager>().maxBulletCount - playerLeft.GetComponent<WeaponManager>().activeBullets.Count);
        playerRightDebug.text = "P2 SCORE: " + SceneManager.Instance.score.playerRightScore.ToString();
        playerRightDebug2.text = "P2 bullets: " + (playerRight.GetComponent<WeaponManager>().maxBulletCount - playerRight.GetComponent<WeaponManager>().activeBullets.Count);
    }
}
