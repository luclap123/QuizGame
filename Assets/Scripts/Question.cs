using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions", fileName = "New questions")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] string textQuestion = "Enter a question";
    [SerializeField] string[] answer = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string getQuestion()
    {
        return textQuestion;
    }

    public string getAnswer(int index)
    {
        return answer[index];
    }

    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
