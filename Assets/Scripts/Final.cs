using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Final : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI showScore;
    Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void finalScore()
    {
        showScore.text = "Your score is " + score.Calculation();
    }


}
