using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
   [SerializeField] private QuestionSO question;
   [SerializeField] private GameObject[] answerButtons;

   private int correctAnswerIndex;
   [SerializeField] private Sprite defaultAnswerSprite;
   [SerializeField] private Sprite correctAnswerSprite;
    void Start()
    {
        DisplayQuestion();
       
    }



    public void OnAnswerSelected(int index)
    {   
        ToggleButtonState(false);
        Image buttonImage;
        if (index == question.GetCorrectIndex()){
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            int correctIndex = question.GetCorrectIndex();
            string correctAnswer = question.GetAnswer(correctIndex);
            questionText.text = "Incorrect! The Correct Answer Was:\n" + correctAnswer;
            buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void DisplayQuestion(){
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(i);            
        } 
    }

    private void GetNextQuestion()
    {
        ToggleButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();

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
        }
    }

}
