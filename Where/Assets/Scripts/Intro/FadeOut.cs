using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public TextIntro lastIntro;
    public Text firstText;
    public Text secondText;
    public Text thirdText;

    public float delay = 3f;
    public float speed = 7f;

    bool started;

    private void Update()
    {
        if (!started)
        {
            if(lastIntro.finished == true)
            {
                started = true;
                InvokeRepeating("Fade", delay, Time.deltaTime);
            }
        }
    }

    void Fade()
    {
        Color temp = firstText.color;
        temp.a = Mathf.Lerp(temp.a, 0f, speed * Time.deltaTime);
        firstText.color = temp;
        temp = secondText.color;
        temp.a = Mathf.Lerp(temp.a, 0f, speed * Time.deltaTime);
        secondText.color = temp;
        temp = thirdText.color;
        temp.a = Mathf.Lerp(temp.a, 0f, speed * Time.deltaTime);
        thirdText.color = temp;
    }
}
