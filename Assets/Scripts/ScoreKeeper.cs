using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{   

    private int questionCount;
    private int correctAnswers = 0;
    private int questionsSeen = 0;

   
    public void SetListCount(int count)
    {
        questionCount = count;
    }

    public int GetListCount()
    {
        return questionCount;
    }

   public int GetCorrectAnswers()
   {
    return correctAnswers;
   }

   public void IncrementCorrectAnswers()
   {
    correctAnswers ++;
   }

   public int GetQuestionsSeen()
   {
    return questionsSeen;
   }

   public void IncrementQuestionsSeen()
   {
    questionsSeen ++;
   }

   public int CalculateScorePercent()
   {
    return Mathf.RoundToInt(correctAnswers / questionsSeen * 100);
   }
}
