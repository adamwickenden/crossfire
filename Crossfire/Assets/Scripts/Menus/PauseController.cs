using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void QuitMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }

    public void Quit()
    {
        // If application is running in the editor, quit the game
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }
}
