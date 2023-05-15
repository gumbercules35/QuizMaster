using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Question", menuName = "QuizMaster/Quiz Question", order = 0)]
public class QuestionSO : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField]string question = "Enter new Question text here";


    public string GetQuestion(){
        return question;
    }
}
