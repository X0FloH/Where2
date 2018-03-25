using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGuards : MonoBehaviour {

    public bool doNow;

    public Shader highlight;
    public Shader defualt;

    public float duration;
    public float cooldown;
    public bool canDo = true;

    public string enableChar = "E";

    private void Update()
    {
        if (doNow)
        {
            foreach (Transform child in transform)
            {
                if(child != transform)
                {
                    child.gameObject.GetComponent<Renderer>().material.shader = highlight;
                }
            }
        } else
        {
            foreach (Transform child in transform)
            {
                if (child != transform)
                {
                    child.gameObject.GetComponent<Renderer>().material.shader = defualt;
                }
            }
        }
        KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), enableChar);
        if (Input.GetKeyDown(thisKeyCode))
        {
            if (canDo)
            {
                canDo = false;
                doNow = true;
                Invoke("Cooldown", duration);
            }
        }
    }

    void Cooldown()
    {
        doNow = false;
        Invoke("ResetShow", cooldown);
    }

    void ResetShow()
    {
        canDo = true;
    }
}
