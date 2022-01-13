using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    public GameObject playerLeft;
    public GameObject playerRight;

    public GameObject leftGoal;
    public GameObject rightGoal;

    public float spawnChance = 0.1f;

    public GameObject board;

    public ScoreManager score;

    public TargetManager targets;

    public PowerUpManager powerUps;

    public static SceneManager Instance { get; private set; }

    public int numTargets = 3;

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
    }

    public void Update()
    {
        targets.RespawnTargets();
        powerUps.RespawnPowerUps();
    }
}
