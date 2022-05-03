using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestion;
    [SerializeField] private Text factText;
    [SerializeField] private Text aText;
    [SerializeField] private Text bText;
    [SerializeField] private Text cText;
    [SerializeField] private Text dText;
        

    private Question currentQuestion;
     void Start() 
    {
        if(unansweredQuestion==null || unansweredQuestion.Count==0)
        {
            unansweredQuestion=questions.ToList<Question>();
        }
        SetCurrentQuestion();
        
        
    }
/*
    public void Soru_Hazirla() {
        List<Question> myQuestionList = new List<Question>();
        int soru_sayisi = 3;
        int sayac = 0;
        while(sayac < soru_sayisi) {
            Question q = new Question("2+2",0,"4","2","3","5");

        }
    }
*/

    void SetCurrentQuestion()
    {
        if(unansweredQuestion.Count == 0) {
            Debug.Log("Oyun bitti.");
            return;
        }

        int randomQuestionIndex=Random.Range(0,unansweredQuestion.Count);
        currentQuestion=unansweredQuestion[randomQuestionIndex];
        
        //Soru ve şıklar ekranda görüntülenir.
        factText.text=currentQuestion.fact;
        aText.text = currentQuestion.a;
        bText.text = currentQuestion.b;
        cText.text = currentQuestion.c;
        dText.text = currentQuestion.d;
        
        unansweredQuestion.RemoveAt(randomQuestionIndex);
    }

    public void checkAnswer(int choice_index) {
        //a :0 b:1 c:2 d:3
        bool is_correct = currentQuestion.trueAnswer == choice_index;

        if(is_correct){
            Debug.Log("Doğru");
        }
        else Debug.Log("Yanlis");

        SetCurrentQuestion();
    }

    }
