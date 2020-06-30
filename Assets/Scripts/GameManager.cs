using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    //public variables
    public Text CorrectAnswer;
    public Text time;
    public Text LosePanelText;
    public Text scoreText;
    public Text HighScoreText;
    public Text AmjadHighScore;
    public GameObject PauseMenu;
    public GameObject losePanel;
    public GameObject SettingsPanel;
    public GameObject Instructions;
    public Slider Volume;


    //private variables
    private int cnt;
    private float highsscore;
    private float timer = 0;
    private int FirstTime;

    private void Start()
    {
        Time.timeScale = 1;
        FirstTime = PlayerPrefs.GetInt("FirstTime");

        if (!GM)
        {
            GM = this;
        }

        if (FirstTime == 1)
        {
            Instructions.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 0);
        }

        else if (FirstTime == 0)
        {
            Instructions.SetActive(false);
        }


        highsscore = PlayerPrefs.GetFloat("HighScore");
    }

    private void Update()
    {
        
        Camera.main.GetComponent<AudioSource>().volume = Volume.value;
        CorrectAnswer.text = "CORRECT: " + "\n" + AnswerChecker.Instance.CorrectAnswer.ToString();
        //Missed.text = "Missed: " + "\n" + AnswerChecker.Instance.Missed.ToString();

        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        time.text = "TIME: " + "\n" + string.Format("{0}:{1}", minutes, seconds);

        if (Input.GetKeyDown(KeyCode.Escape) && cnt == 0)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            cnt = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && cnt == 1)
        {
            resume();
        }
    }

    public void Sleep()
    {
        Time.timeScale = 0;
        float sscore = Mathf.Ceil(timer) * 100 + AnswerChecker.Instance.CorrectAnswer * 10;
        scoreText.text = "SCORE: " + sscore.ToString();
        HighScoreText.text = "HIGHESTSCORE: " + PlayerPrefs.GetFloat("HighScore").ToString();

        if (sscore > highsscore)
        {
            PlayerPrefs.SetFloat("HighScore", sscore);
        }

        losePanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        cnt = 0;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        //Time.timeScale = 1;
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }


}
