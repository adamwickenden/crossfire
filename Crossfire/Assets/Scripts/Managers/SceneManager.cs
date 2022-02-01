using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    [SerializeField]
    public GameObject playerLeft;
    [SerializeField]
    public GameObject playerLeftControl;
    [SerializeField]
    public GameObject playerRight;
    [SerializeField]
    public GameObject playerRightControl;
    [SerializeField]
    public float spawnChance = 0.1f;
    [SerializeField]
    public int numTargets = 1;
    [SerializeField]
    public GameObject pauseCanvas;
    [SerializeField]
    public GameObject scoreCanvas;


    [HideInInspector]
    public GameObject leftGoal;
    [HideInInspector]
    public GameObject rightGoal;
    [HideInInspector]
    public GameObject board;


    public ScoreManager score;
    public TargetManager targets;
    public PowerUpManager powerUps;
    public static SceneManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        score = new ScoreManager();

        targets = new TargetManager(numTargets);
        targets.InitialSpawn();

        powerUps = new PowerUpManager(spawnChance);

        // Cache references to all desired variables
        playerLeft = GameObject.Find("PlayerLeft");
        playerRight = GameObject.Find("PlayerRight");

        leftGoal = GameObject.Find("LeftGoal");
        rightGoal = GameObject.Find("RightGoal");

        board = GameObject.Find("Board");

        // Enforce timescale
        Time.timeScale = 1f;

        // Set up playerLeft based on MenuState
        if (MenuState.playerLeftControl == 0){
            Debug.Log("Setting player 1 to Human");
            playerLeftControl.GetComponent<PlayerManager>().humanControlled = true;
           
            if (MenuState.playerLeftInput == 0) {
                Debug.Log("Setting player 1 to Keyboard&Mouse");
                playerLeftControl.transform.Find("Human").gameObject.GetComponent<PlayerInput>().defaultControlScheme = "Keyboard&Mouse";
            }
            else if (MenuState.playerLeftInput == 1) {
                Debug.Log("Setting player 1 to Gamepad");
                playerLeftControl.transform.Find("Human").gameObject.GetComponent<PlayerInput>().defaultControlScheme = "Gamepad";
            }
        }
        else {
            Debug.Log("Setting player 1 to AI");
            playerLeftControl.GetComponent<PlayerManager>().humanControlled = false;
        }

        // Set up playerRight based on MenuState
        if (MenuState.playerRightControl == 0){
            Debug.Log("Setting player 2 to Human");
            playerRightControl.GetComponent<PlayerManager>().humanControlled = true;

            if (MenuState.playerRightInput == 0) {
                Debug.Log("Setting player 2 to Keyboard&Mouse");
                playerRightControl.transform.Find("Human").gameObject.GetComponent<PlayerInput>().defaultControlScheme = "Keyboard&Mouse";
            }
            else if (MenuState.playerLeftInput == 1) {
                Debug.Log("Setting player 2 to Gamepad");
                playerRightControl.transform.Find("Human").gameObject.GetComponent<PlayerInput>().defaultControlScheme = "Gamepad";
            }
        }
        else {
            Debug.Log("Setting player 2 to AI");
            playerRightControl.GetComponent<PlayerManager>().humanControlled = false;
        }
    }

    public void Update()
    {
        targets.RespawnTargets();
        powerUps.RespawnPowerUps();
    }
}
