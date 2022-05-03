[System.Serializable]
public class Question 
{      
    public string fact;
    public int trueAnswer;
    public string a;
    public string b;
    public string c;
    public string d;

    public Question(string fact_p, int trueAnswer_p, string a_p, string b_p, string c_p, string d_p) {
        fact = fact_p;
        trueAnswer = trueAnswer_p;
        a = a_p;
        b = b_p;
        c = c_p;
        d = d_p;
    }
    
}
