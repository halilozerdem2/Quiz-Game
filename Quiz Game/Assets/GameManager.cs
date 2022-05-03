using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestion;

//Text değişkenini kullanmak için unityengine ui kütüphanesini eklemelisiniz
    [SerializeField] private Text factText;
    [SerializeField] private Text aText;
    [SerializeField] private Text bText;
    [SerializeField] private Text cText;
    [SerializeField] private Text dText;
    public int trueAnswers; // Bu değişken doğru sayısını tutuyor
    public int falseAnswers;// Bu değişken yanlış sayısını tutuyor

        

    private Question currentQuestion; //Ekrandaki anlık soruyu temsil eder
     void Start() 
    {
        if(unansweredQuestion==null || unansweredQuestion.Count==0) //Sorulmuş soruların soru havuzu listesinden çıkarılmasını sağlar
        {
            unansweredQuestion=questions.ToList<Question>();
        }

        SetCurrentQuestion();//Random soru çağırma fonksiyonu
        
        
    }
    

    void SetCurrentQuestion()
    {
        if(unansweredQuestion.Count==0)//Sorular bittiği zaman olacak eventler buraya yazılır.
        {
            Debug.Log("Dogru soru sayiniz "+trueAnswers);
            Debug.Log("Yanlis soru sayiniz "+falseAnswers);
            Debug.Log("Oyun bitti!!");
            return;
        }
        int randomQuestionIndex=Random.Range(0,unansweredQuestion.Count); //Rastgele soru üretme.
        currentQuestion=unansweredQuestion[randomQuestionIndex];
        unansweredQuestion.RemoveAt(randomQuestionIndex);//Sorulmuş soruların soru havuzu listesinden çıkarılmasını sağlar

        //alt satırdaki atamaların tamamı Uİ üzerinde Text değişkenleri ile string değişkenlerinin
        //birbirine bağlanması için kurulmuştur.
        factText.text=currentQuestion.fact; 
        aText.text=currentQuestion.a;
        bText.text=currentQuestion.b;
        cText.text=currentQuestion.c;
        dText.text=currentQuestion.d;
        
    }

    public void checkAnswer(int choice_index)// Buttonların onClick eventlarında kullanıdğımız fonksiyondur.
    //buttonlara birer index ataması yapmak için ve cevapların doğru olup olmadığının kontrolünü yapmak için kullanılır.
    {
     //a=0 , b=1 , c=2 , d=3  
     bool isCorrect =currentQuestion.trueAnswer==choice_index;
    
    if(isCorrect)
    {
        Debug.Log("Doğru!");
        //doğru cevaplanmış soru sayısı sayacı arttırılır.
        trueAnswers++;

    } 
    else {
        Debug.Log("Yanlis!");
        //yanlış cevaplanmış soru sayısı sayacı arttırılır.
        falseAnswers++;
    }
    //Sonraki sorunun çağırılması için çağırılır..

     SetCurrentQuestion();

    }
}