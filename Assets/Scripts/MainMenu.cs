using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject InfoPanel;

    private void Start()
    {
        PlayerPrefs.SetInt("FirstTime", 1);

        if(Time.timeScale <=0)
        {
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenInfoPanel()
    {
        InfoPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
