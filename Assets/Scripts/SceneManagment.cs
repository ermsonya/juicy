using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneManagment : MonoBehaviour
{
    public TextMeshProUGUI record;
    public TextMeshProUGUI score;
    public static int numberScore;

    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startText;


    // Start is called before the first frame update
    void Start()
    {
        record.text = "Record: " + PlayerPrefs.GetInt("Record", 0).ToString();
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        score.text = "" + numberScore;
        if (numberScore > PlayerPrefs.GetInt("Record", 0))
        {
            PlayerPrefs.SetInt("Record", numberScore);
            record.text = "Record: " + numberScore.ToString();
        }
        if (Input.GetMouseButton(0))
        {
            isGameStarted = true;
            Destroy(startText);
        }
    }
}
