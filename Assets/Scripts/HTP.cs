using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTP : MonoBehaviour
{
    public Image Instructs;
    public Sprite[] instructionsImage;
    public GameObject ReadyToPlayButton;
    public GameObject NextButton;

    private int cnt = 0 ;
    //private bool firstTime ;

    private void Start()
    {
        Time.timeScale = 0;
        Instructs.sprite = instructionsImage[cnt];
    }

    public void ShowInstruction()
    {
        cnt++;
        Instructs.sprite = instructionsImage[cnt];
    }

    private void Update()
    {
        if(cnt == instructionsImage.Length - 1)
        {
            ReadyToPlayButton.SetActive(true);
            NextButton.SetActive(false);
        }
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


}
