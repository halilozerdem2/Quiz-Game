using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestion;

    private Question currentQuestion;
     void Start() 
    {
        if(unansweredQuestion==null || unansweredQuestion.Count==0)
        {
            unansweredQuestion=questions.ToList<Question>();
        }
        GetRandomQuestion();
        
        Debug.Log(currentQuestion.fact+" "+ currentQuestion.trueAnswer);
        
    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex=Random.Range(0,unansweredQuestion.Count);
        currentQuestion=unansweredQuestion[randomQuestionIndex];
        
        unansweredQuestion.RemoveAt(randomQuestionIndex);
    }
   
}
