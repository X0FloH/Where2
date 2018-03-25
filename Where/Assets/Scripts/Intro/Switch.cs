using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour {

    public TextIntro lastIntro;

    public float delay;

    private void Update()
    {
        if (lastIntro.finished)
        {
            Invoke("SwitchNow", delay);
        }
    }

    void SwitchNow()
    {
        SceneManager.LoadScene(1);
    }
}
