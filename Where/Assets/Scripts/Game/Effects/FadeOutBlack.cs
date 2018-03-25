using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutBlack : MonoBehaviour {

    public GameObject panel;

    public float speed = 2f;
    public bool now;

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
        if(panel.GetComponent<Image>().color.a >= 0.99 && now)
        {
            SceneManager.LoadScene(1);
        }
    }

    void Fade()
    {
        Image im = panel.GetComponent<Image>();
        Color temp = im.color;
        temp.a = Mathf.Lerp(temp.a, 1f, speed * Time.deltaTime);
        im.color = temp;
    }
}
