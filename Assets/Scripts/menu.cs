using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject canvas;
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        SceneManagment.isGameStarted = true;
    }

  private void Pause()
    {
        SceneManagment.isGameStarted = false;
        canvas.SetActive(true);
    }
   public void PauseClick()
    {
        Time.timeScale = 0;
        SceneManagment.isGameStarted = false;
        canvas.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause();
        }
    }
}