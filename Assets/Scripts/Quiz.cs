using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI textQuestions;
    [SerializeField] List<Question> questions = new List<Question>();
    Question currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answer;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Show answers")]
    [SerializeField] Sprite defaultImageAnswer;
    [SerializeField] Sprite correctImageAnswer;

    [Header("Time")]
    [SerializeField] Image timerImage;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        // OnNextQuestion();
        // DisplayQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            OnNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    void DisplayQuestion()
    {
        textQuestions.fontSize = 100;
        textQuestions.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answer.Length; i++)
        {
            TextMeshProUGUI textAnswer = answer[i].GetComponentInChildren<TextMeshProUGUI>();
            textAnswer.text = currentQuestion.GetAnswer(i);
            textAnswer.color = Color.yellow;
        }
    }

    void OnNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
        }

    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void SetDefaultButtonSprite()
    {
        Image buttonImg;
        for (int i = 0; i < answer.Length; i++)
        {
            buttonImg = answer[i].GetComponent<Image>();
            buttonImg.sprite = defaultImageAnswer;
        }
    }

    public void OnAnswerSlected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    public void DisplayAnswer(int index)
    {
        Image buttonImg;
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            textQuestions.text = "you chose correct answer";
            buttonImg = answer[index].GetComponent<Image>();
            buttonImg.sprite = correctImageAnswer;
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string textCorrectAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            textQuestions.fontSize = 40;
            textQuestions.text = "You chose wrong answer, the answer was \n" + textCorrectAnswer;
            buttonImg = answer[correctAnswerIndex].GetComponent<Image>();
            buttonImg.sprite = defaultImageAnswer;

        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            Button button = answer[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
