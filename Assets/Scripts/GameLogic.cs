using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Time.timeScale = 1f;
            RestartLevel();
        }
    }

    public void QuitGame()
    {
        // This function is called when the "Q" key is pressed
        // You can add additional logic or cleanup before quitting, if needed
        Debug.Log("Quitting the game!");
        Application.Quit();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
