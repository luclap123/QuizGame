using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion = 20f;
    [SerializeField] float timeToShowQuestion = 10f;

    public bool isAnsweringQuestion = false;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue <=0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowQuestion;
            }
        }
        else
        {
            if (timerValue<=0)
            {
                isAnsweringQuestion = true;
                timerValue = timeToAnswerQuestion;
            }
        }
        // if (timerValue <= 0)
        // {
        //     isAnsweringQuestion = true;
        //     timerValue = timeToAnswerQuestion;
        // }
        Debug.Log(timerValue);
    }
}
