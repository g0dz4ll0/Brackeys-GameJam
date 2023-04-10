using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenu_Panel;
    public bool isPaused;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu_Panel.active)
            {
                isPaused = false;
                Time.timeScale = 1.0f;
            } 
            else
            {
                isPaused = true;
                Time.timeScale = 0.0f;
            }

            PauseMenu_Panel.SetActive(!PauseMenu_Panel.activeSelf);
        }

    }


    public void ContinueGame()
    {
        if (isPaused)
        {
            PauseMenu_Panel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
        }
        else
        {
            PauseMenu_Panel.SetActive(true);
            Time.timeScale = 0.0f;
            isPaused = true;
        }
    }

    public void MainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
