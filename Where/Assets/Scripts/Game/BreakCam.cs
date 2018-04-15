using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCam : MonoBehaviour {

    public Material dark;
    public bool swtch;
    public GameObject camDisp;
    public GameObject camDisp2;
    public GameObject flare;

    private void Update()
    {
        if (swtch)
        {
            camDisp.GetComponent<Renderer>().material = dark;
            camDisp2.GetComponent<Renderer>().material = dark;
            flare.SetActive(true);
        }
    }
}
