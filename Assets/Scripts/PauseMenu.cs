using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenu_Panel;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu_Panel.active) Time.timeScale = 1.0f;
            else Time.timeScale = 0.0f;

            PauseMenu_Panel.SetActive(!PauseMenu_Panel.activeSelf);
        }

    }


    public void ContinueGame()
    {

        PauseMenu_Panel.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
