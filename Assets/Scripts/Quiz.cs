using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
   [SerializeField] private QuestionSO question;
    void Start()
    {
        questionText.text = question.GetQuestion();
    }

}
