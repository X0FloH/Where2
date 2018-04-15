using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditShowGuards : MonoBehaviour {

    public ShowGuards showGuards;

    public bool doNow;
    public bool overide;
    public bool canDo;

    private void Update()
    {
        if (overide)
        {
            showGuards.doNow = doNow;
            showGuards.canDo = canDo;
        }
    }
}
