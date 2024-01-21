using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Final : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI showScore;
    Score score;

    void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    public void finalScore()
    {
        showScore.text = "Your score is " + score.Calculation();
    }


}
