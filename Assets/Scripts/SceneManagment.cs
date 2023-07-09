using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManagment : MonoBehaviour
{
    public TextMeshProUGUI record;
    public TextMeshProUGUI score;
    public TextMeshProUGUI timerText;

    public int maxHealth = 5;
    public int timerSeconds = 3;

    public static int numberScore = 0;
    public static int health;
    public static bool isGameStarted;
    public static bool gameOver;

    public GameObject tutorialPanel;
    public GameObject gameOverPanel;
    public GameObject startText;

    private static List<GameObject> _healthList = new List<GameObject>();

    void Start()
    {
        record.text = "Record: " + PlayerPrefs.GetInt("Record", 0).ToString();
        Time.timeScale = 1;
        isGameStarted = false;
        gameOver = false;
        numberScore = 0;
        health = maxHealth;

        foreach (GameObject healthTile in GameObject.FindGameObjectsWithTag("health"))
            _healthList.Add(healthTile);

        StartCoroutine(TimerSchedule());
    }

    void Update()
    {
        if (health <= 0)
            gameOver = true;

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        score.text = "Score: " + numberScore;
        if (numberScore > PlayerPrefs.GetInt("Record", 0))
        {
            PlayerPrefs.SetInt("Record", numberScore);
            record.text = "Record: " + numberScore.ToString();
        }

        if (Input.GetMouseButton(0) && timerSeconds == 0)
        {
            isGameStarted = true;
            Destroy(startText);
            Destroy(tutorialPanel);
        }
    }

    public static void RemoveHealth()
    {
        if (health <= 0)
            return;

        health--;
        Destroy(_healthList[^1]);
        _healthList.Remove(_healthList[^1]);
    }

    private IEnumerator TimerSchedule()
    {
        tutorialPanel.SetActive(true);
        startText.SetActive(false);
        timerText.text = timerSeconds.ToString();

        while (timerSeconds > 0)
        {
            yield return new WaitForSeconds(1f);

            timerSeconds--;
            timerText.text = timerSeconds.ToString();
        }

        if (timerSeconds == 0)
        {
            timerText.gameObject.SetActive(false);
            startText.SetActive(true);
        }
    }
}