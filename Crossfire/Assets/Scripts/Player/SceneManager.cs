using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    public GameObject playerLeft;
    public GameObject playerRight;
    public static SceneManager Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        // Cache references to all desired variables
        playerLeft = GameObject.Find("PlayerLeft");
        playerRight = GameObject.Find("PlayerRight");
    }
}
