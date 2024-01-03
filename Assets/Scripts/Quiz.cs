using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textQuestions;
    [SerializeField] Question question;
    [SerializeField] GameObject[] answer;
    // Start is called before the first frame update
    void Start()
    {
        textQuestions.fontSize = 100;
        textQuestions.text = question.getQuestion();
        for (int i = 0; i < answer.Length; i++)
        {
            TextMeshProUGUI textAnswer = answer[i].GetComponentInChildren<TextMeshProUGUI>();
            textAnswer.text = question.getAnswer(i);
            textAnswer.color = Color.yellow;
        }
    }


}
