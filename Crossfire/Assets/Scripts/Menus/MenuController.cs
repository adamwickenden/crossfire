using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerMenu1;
    [SerializeField]
    public GameObject playerMenu2;
    [SerializeField]
    public GameObject warning;

    // Play
    public void Play()
    {
        // Get Control Objects
        GameObject player1Control = playerMenu1.transform.Find("Control").gameObject;
        GameObject player2Control = playerMenu2.transform.Find("Control").gameObject;
        // Get Input Objects
        GameObject player1Input = playerMenu1.transform.Find("Input").gameObject;
        GameObject player2Input = playerMenu2.transform.Find("Input").gameObject;

        if (
            player1Control.GetComponent<Dropdown>().value != player2Control.GetComponent<Dropdown>().value
            ||
            (
                player1Control.GetComponent<Dropdown>().value == player2Control.GetComponent<Dropdown>().value
                &&
                player1Input.GetComponent<Dropdown>().value != player2Input.GetComponent<Dropdown>().value
            )
        )
        {
            // Set values for player 1
            MenuState.playerLeftControl = player1Control.GetComponent<Dropdown>().value;
            // Set input based upon control
            if (MenuState.playerLeftControl == 0){
                MenuState.playerLeftInput = player1Input.GetComponent<Dropdown>().value;
            }
            else {
                MenuState.playerLeftInput = -1;
            }

            // Set values for player 2
            MenuState.playerRightControl = player2Control.GetComponent<Dropdown>().value;
            // Set input based upon control
            if (MenuState.playerRightControl == 0){
                MenuState.playerRightInput = player2Input.GetComponent<Dropdown>().value;
            }
            else {
                MenuState.playerRightInput = -1;
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        }
        else if (player1Control.GetComponent<Dropdown>().value == 1 && player1Control.GetComponent<Dropdown>().value == 1){
            warning.SetActive(true);
            warning.GetComponent<TMPro.TextMeshProUGUI>().text = "At least one player must be Human.";
        }
        else
        {
            warning.SetActive(true);
            warning.GetComponent<TMPro.TextMeshProUGUI>().text = "Players must use different controllers.";
        }
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
