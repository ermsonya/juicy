using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("background");
    }

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
}
