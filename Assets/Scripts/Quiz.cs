using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private List<QuestionSO> questionsList = new List<QuestionSO>();
   private QuestionSO currentQuestion;

    [Header("Answers")]
   [SerializeField] private GameObject[] answerButtons;
   private int correctAnswerIndex;
   private bool hasAnswered = false;

   [Header("Button Sprites")]
   [SerializeField] private Sprite defaultAnswerSprite;
   [SerializeField] private Sprite correctAnswerSprite;

   [Header("Timer")]
   [SerializeField] private Image timerImage;
   private Timer timer;

   [Header("Scoring")]
   [SerializeField] TextMeshProUGUI scoreText;
   ScoreKeeper scoreKeeper;

   [Header("Progress Bar")]
   [SerializeField] private Slider progressBar;

   [Header("Audio")]
   private AudioHandler audioHandler;

   public bool isComplete = false;
   private void Awake()
   {
        timer = FindObjectOfType<Timer>();
       scoreKeeper = FindObjectOfType<ScoreKeeper>();
       audioHandler = FindObjectOfType<AudioHandler>();
   }
    void Start()
    {
       scoreKeeper.SetListCount(questionsList.Count);
       scoreText.text = "Score: " + scoreKeeper.GetCorrectAnswers() + "/" + scoreKeeper.GetListCount();
       progressBar.maxValue = questionsList.Count;
       progressBar.value = 0;
       
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion){
            if(progressBar.value == progressBar.maxValue){
            isComplete = true;
            return;
        }
            hasAnswered = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } 
        else if (!hasAnswered && !timer.GetAnsweringState())
        {

            DisplayAnswer(-1);
            ToggleButtonState(false);
            hasAnswered = true;
            
        }
        
    }


    
    public void OnAnswerSelected(int index)
    {   
        hasAnswered = true;
        DisplayAnswer(index);
        timer.AnswerSelected();
        ToggleButtonState(false);
        scoreText.text = "Score: " + scoreKeeper.GetCorrectAnswers() + "/" + scoreKeeper.GetListCount();
        
        
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        int correctIndex = currentQuestion.GetCorrectIndex();

        for (int i = 0; i < answerButtons.Length; i++){
                if ( i != correctIndex){
                buttonImage = answerButtons[i].GetComponent<Image>();
                buttonImage.color = Color.red;
                }
                else {
                  buttonImage = answerButtons[i].GetComponent<Image>();
                buttonImage.color = Color.green;  
                }
            }

        if (index == correctIndex){
            audioHandler.PlaySounds(true);
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();            
        } else {
            audioHandler.PlaySounds(false);
            string correctAnswer = currentQuestion.GetAnswer(correctIndex);
            questionText.text = "Incorrect! The Correct Answer Was:\n" + correctAnswer;
            buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite; 
                    
        }
    }

    private void DisplayQuestion(){
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = currentQuestion.GetAnswer(i);            
        } 
    }

    private void GetNextQuestion()
    {
        if(questionsList.Count >= 1)
        {
            ToggleButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.IncrementQuestionsSeen();
            progressBar.value ++;
        }

    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, questionsList.Count);
        currentQuestion = questionsList[index];
        if(questionsList.Contains(currentQuestion))
        {
          questionsList.Remove(currentQuestion);
        }
    }
    

    private void ToggleButtonState (bool state){
        Button button;
        foreach (GameObject answerButton in answerButtons)
        {
            button = answerButton.GetComponent<Button>();
            button.interactable = state;
        }
    }
    
    private void SetDefaultButtonSprite (){
        Image buttonImage;
        foreach (GameObject answerButton in answerButtons)
        {
            buttonImage = answerButton.GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            buttonImage.color = Color.white;
        }
    }

}
