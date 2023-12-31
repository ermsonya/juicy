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
        FindObjectOfType<AudioManager>().Play("button_click");
    }

    public void QuitGame()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("button_click");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("MainScene");
        FindObjectOfType<AudioManager>().Play("button_click");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("button_click");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        SceneManagment.isGameStarted = true;
        FindObjectOfType<AudioManager>().Play("button_click");
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
        FindObjectOfType<AudioManager>().Play("button_click");
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