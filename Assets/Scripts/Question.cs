using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions", fileName = "New questions")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] string textQuestion = "Enter a question";
}
