using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSlomo : MonoBehaviour {

    public bool reset;

    private void Update()
    {
        if (reset)
        {
            reset = false;
            Time.timeScale = 1f;
        }
    }
}
