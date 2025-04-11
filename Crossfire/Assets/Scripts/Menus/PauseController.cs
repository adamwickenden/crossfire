using UnityEngine;

public class PauseController : MonoBehaviour
{
	public void QuitMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("title");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
