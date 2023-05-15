using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{  
    [SerializeField] private float timeToAnswer = 30f;
    [SerializeField] private float timeToWait = 10f;
    public bool isAnswering = false;
    private float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer ()
    {
        timerValue -= Time.deltaTime;

        if (timerValue <= 0)
        {           
            isAnswering = !isAnswering;
            if(isAnswering)
            {
                timerValue = timeToAnswer;
            } else {
                timerValue = timeToWait;
            }
        }

        Debug.Log(timerValue);
    }
}
