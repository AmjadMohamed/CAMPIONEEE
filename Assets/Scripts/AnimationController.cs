using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator m_Animator;

    float temp = 10;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetInteger("DanceNumber", Random.Range(0, 1));
    }

    private void Update()
    {
        temp -= Time.deltaTime;

        if(temp <= 0)
        {
            m_Animator.SetInteger("DanceNumber", Random.Range(0, 1));
            temp = 10;
        }
    }
}
