using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseNewIntro : MonoBehaviour {

    public TextIntro firstIntro;
    public TextIntro secondIntro;
    public float delay = 0.1f;

    bool caused;

    private void Update()
    {
        if (!caused)
        {
            if (firstIntro.finished)
            {
                Invoke("startNow", delay);
                caused = true;
            }
        }
    }

    void startNow()
    {
        secondIntro.startNow = true;
    }
}
