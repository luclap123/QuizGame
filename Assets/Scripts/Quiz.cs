using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textQuestions;
    [SerializeField] Question question;
    [SerializeField] GameObject[] answer;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultImageAnswer;
    [SerializeField] Sprite correctImageAnswer;
    // Start is called before the first frame update
    void Start()
    {
        textQuestions.fontSize = 100;
        textQuestions.text = question.GetQuestion();
        for (int i = 0; i < answer.Length; i++)
        {
            TextMeshProUGUI textAnswer = answer[i].GetComponentInChildren<TextMeshProUGUI>();
            textAnswer.text = question.GetAnswer(i);
            textAnswer.color = Color.yellow;
        }
    }

    public void OnAnswerSlected(int index)
    {
        Image buttonImg;
        if (index == question.GetCorrectAnswerIndex())
        {
            textQuestions.text = "you chose correct answer";
            buttonImg = answer[index].GetComponent<Image>();
            buttonImg.sprite = correctImageAnswer;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string textCorrectAnswer = question.GetAnswer(correctAnswerIndex);
            textQuestions.fontSize = 40;
            textQuestions.text = "You chose wrong answer, the answer was \n"+textCorrectAnswer;
            buttonImg = answer[correctAnswerIndex].GetComponent<Image>();
            buttonImg.sprite = defaultImageAnswer;

        }
    }
}
