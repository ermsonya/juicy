using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }  
}
