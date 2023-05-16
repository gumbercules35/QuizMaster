using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Quiz quiz;
    private CompleteQuiz completeQuiz;

    private void Awake() 
    {
        quiz = FindObjectOfType<Quiz>();
        completeQuiz = FindObjectOfType<CompleteQuiz>();        
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        completeQuiz.gameObject.SetActive(false);
    }

    void Update()
    {
       if (quiz.isComplete)
       {
        QuizCompleted();
       }
    }

    private void QuizCompleted ()
    {
        quiz.gameObject.SetActive(false);
        completeQuiz.gameObject.SetActive(true);
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
