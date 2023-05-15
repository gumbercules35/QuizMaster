using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Question", menuName = "QuizMaster/Quiz Question", order = 0)]
public class QuestionSO : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter new Question text here";
    [SerializeField] private string[] answerArray = new string[3];
    [SerializeField] private int correctIndex;
    public string GetQuestion(){
        return question;
    }

    public int GetCorrectIndex(){
        return correctIndex;
    }

    public string GetAnswer(int index){
        return answerArray[index];
    }
}
