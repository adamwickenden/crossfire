using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Play
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
}
