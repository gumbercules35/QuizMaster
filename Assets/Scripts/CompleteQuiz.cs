using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompleteQuiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();        
    }
    void Start()
    {
        ShowFinalScore();
    }

    public void ShowFinalScore()
    {
        int finalScore = scoreKeeper.GetCorrectAnswers();
        finalScoreText.text = "Congratulations!\nYou Scored: " + finalScore + "/" + scoreKeeper.GetListCount();
    }
}
