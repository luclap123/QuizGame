using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textQuestions;
    [SerializeField] Question question;
    // Start is called before the first frame update
    void Start()
    {
        textQuestions.fontSize = 100;
        textQuestions.text = question.getQuestion();
    }


}
