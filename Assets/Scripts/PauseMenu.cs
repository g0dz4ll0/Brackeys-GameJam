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
            PauseMenu_Panel.SetActive(!PauseMenu_Panel.activeSelf);
        }

    }


    public void ContinueGame()
    {

        PauseMenu_Panel.SetActive(false);

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
