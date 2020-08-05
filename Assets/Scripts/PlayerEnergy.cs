using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    // public variables
    public Slider m_Slider;
    public Image fill;
    public GameObject Pointer;
    public GameObject InfectiousRateIncreased;

    // private variables
    float RandomDecreaseRate;
    float temp = 5;
    float timeToIncreaseRate = 15f;
    float IncreaseRate = 0;
    RaycastHit2D hit;
    Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        RandomDecreaseRate = Random.Range(0.01f, 0.04f);
        m_Animator.SetInteger("DanceNumber", Random.Range(1, 3));
    }

    private void Update()
    {
        // select a player to increase his energy when hit the right keyboard key 
        if (Time.timeScale > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            }

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == this.gameObject.name)
                {
                    this.transform.tag = "Targeted";
                }

                else
                {
                    this.transform.tag = "Player";
                }
            }

            if (this.transform.tag == "Targeted" )
            {
                Pointer.SetActive(true);
                if(AnswerChecker.Instance.IsTargeted)
                    m_Slider.value = m_Slider.value - RandomDecreaseRate + AnswerChecker.Instance.PlusDecreaseVal + IncreaseRate;
            }
            else if (this.transform.tag == "Player")
            {
                Pointer.SetActive(false);
                m_Slider.value = m_Slider.value - RandomDecreaseRate;
            }

            FillColorAndAnimationChange();

            temp -= Time.deltaTime;

            if (temp <= 0)
            {
                m_Animator.SetInteger("DanceNumber", Random.Range(1, 3));
                temp = 5;
            }

            timeToIncreaseRate -= Time.deltaTime;

            if (timeToIncreaseRate <= 0)
            {
                IncreaseRate += 5;
                RandomDecreaseRate += 0.02f;
                timeToIncreaseRate = 15f;
                StartCoroutine(InfectiousRate());
            }
        }
        if (m_Slider.value <= 0)
        {
            GameManager.GM.LosePanelText.text = this.transform.name.ToUpper() + " GOT TIRED AND FALL" + "\n" + "ASLEEP :(";
            //StartCoroutine(Sleep());
            GameManager.GM.Sleep();
        }


    }

    void FillColorAndAnimationChange()
    {
        var sliderFill = m_Slider.value;

        Color orange = new Color(1f, 0.66f, 0.11f);
        Color green = new Color(0f, .63f, .31f);
        Color yellow = new Color(1, .82f, 0);

        if (sliderFill > 75)
        {
            fill.color = green;
            m_Animator.SetFloat("Speed", 1);
        }

        else if (sliderFill > 50 && sliderFill < 75)
        {
            fill.color = Color.Lerp(green, yellow, 1);
            m_Animator.SetFloat("Speed", .75f);
        }

        else if (sliderFill > 25 && sliderFill < 50)
        {
            fill.color = Color.Lerp(yellow, orange, 1);
            m_Animator.SetFloat("Speed", .5f);
        }

        else if (sliderFill < 25)
        {
            fill.color = Color.Lerp(orange, Color.red, 1);
            m_Animator.SetFloat("Speed", .25f);
        }


    }
    IEnumerator InfectiousRate()
    {
        InfectiousRateIncreased.SetActive(true);
        yield return new WaitForSeconds(3);
        InfectiousRateIncreased.SetActive(false);
    }

  /*  IEnumerator Sleep()
    {
        m_Animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(1);
        GameManager.GM.Sleep();
    }*/
}
