using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    Final final;
    Question question;
    // Start is called before the first frame update
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        final = FindObjectOfType<Final>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        final.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isCompleted)
        {
            quiz.gameObject.SetActive(false);
            final.gameObject.SetActive(true);
            final.finalScore();
        }
    }

    public void RealoadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
