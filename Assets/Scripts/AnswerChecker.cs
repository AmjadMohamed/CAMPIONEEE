using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    public static AnswerChecker Instance;

    // Private Variables 
    string key, objectCollided;
    int CollisionCounter = 0;
    bool RightButtonPressed = false;

    Animator m_Animator;

    //public variables
    [HideInInspector]
    public int PlusDecreaseVal = 20;
    [HideInInspector]
    public bool IsTargeted = false;
    [HideInInspector]
    public int CorrectAnswer = 0;
    //public int Missed = 0;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();

        if(!Instance)
        {
            Instance = this;
        }
    }


    private void Update()
    {
        if (CollisionCounter == 1)
        {
            if (Input.inputString.ToUpper() == objectCollided)
            {
                RightAnswer();
                PlusDecreaseVal = 20;
                IsTargeted = true;
                CorrectAnswer++;
            }
            else
            {
                RightButtonPressed = false;
            }
        }
        else
        {
            PlusDecreaseVal = 0;
            IsTargeted = false;
            if (!RightButtonPressed && CollisionCounter == 0)
            {
                WrongAnswer();
            }
            else
            {
                DefaultBar();
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionCounter = 1;
        objectCollided = collision.transform.name[0].ToString();
        m_Animator.SetBool("ReadyToAnswer", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CollisionCounter = 0;
        Destroy(collision.gameObject);
    }

    void RightAnswer()
    {
        m_Animator.SetBool("IsTrue", true);
        m_Animator.SetBool("IsFalse", false);
        CollisionCounter = 0;
        //PlusDecreaseVal = 5;
        RightButtonPressed = true;
    }

    void WrongAnswer()
    {
        m_Animator.SetBool("IsFalse", true);
        m_Animator.SetBool("IsTrue", false);
        //PlusDecreaseVal = -5;
    }

    void DefaultBar()
    {
        m_Animator.SetBool("IsTrue", false);
        m_Animator.SetBool("IsFalse", false);
        m_Animator.SetBool("ReadyToAnswer", false);
        //PlusDecreaseVal = 0;
    }






}
