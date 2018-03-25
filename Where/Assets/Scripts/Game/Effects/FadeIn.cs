using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public GameObject panel;

    public float speed = 7f;
    public bool now;

    public bool readyNow;

    bool done;

    private void Update()
    {
        if (!done)
        {
            if (now)
            {
                done = true;
                InvokeRepeating("Fade", 0.0f, Time.deltaTime);
            }
        }
        if (!now)
        {
            CancelInvoke();
        }
    }

    void Fade()
    {
        Image im = panel.GetComponent<Image>();
        Color temp = im.color;
        temp.a = Mathf.Lerp(temp.a, 0f, speed * Time.deltaTime);
        im.color = temp;
        if(temp.a < 0.05f)
        {
            now = false;
            readyNow = true;
        }
    }

}
