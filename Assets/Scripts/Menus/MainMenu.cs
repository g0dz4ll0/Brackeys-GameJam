using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject OptionsMenuPrefab;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

    public void Options()
    {

        mainMenu.SetActive(false);
        OptionsMenuPrefab.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
