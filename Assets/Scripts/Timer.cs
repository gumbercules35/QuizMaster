using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{  
    [SerializeField] private float timeToAnswer = 30f;
    [SerializeField] private float timeToWait = 10f;
    public float fillFraction;
    private bool isAnswering = false;
    public bool loadNextQuestion = false;
    private float timerValue;
   
    void Update()
    {
        UpdateTimer();
    }

    public bool GetAnsweringState(){
        return isAnswering;
    }
    public void AnswerSelected()
    {
        timerValue = 0;
    }

    private void UpdateTimer ()
    {
        timerValue -= Time.deltaTime;
        fillFraction = timerValue / (isAnswering ? timeToAnswer : timeToWait);
        if(isAnswering){
            if (timerValue <= 0)
            {
                isAnswering = false;
                timerValue = timeToWait;            
            }
        } else {
            if(timerValue <= 0)
            {
                isAnswering = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }

    
    }
}
