using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextIntro : MonoBehaviour {

    public string text;
    public Text textPlace;
    public bool startNow;
    public float delay = 0.2f;

    public bool finished;

    public bool started;

   public int charC = 0;

    private void Update()
    {
        if (!started)
        {
            if (startNow)
            {
                InvokeRepeating("addLetter", 0f, delay);
                started = true;
                startNow = false;
            }
        } 
    }

    void addLetter()
    {
        print(charC);
        print(text.Length);
        if(charC == text.Length-1)
        {
            finished = true;
            CancelInvoke();
        }
        textPlace.text += text[charC];
        charC += 1;
    }
}
