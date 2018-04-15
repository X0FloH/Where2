using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public Vector3 force;
    public bool xDeltaTime;
    public bool doNow;
    public ForceMode fMode;

    private void Update()
    {
        if (xDeltaTime)
        {
            if (doNow)
            {
                doNow = false;
                GetComponent<Rigidbody>().AddForce(force * Time.deltaTime, fMode);
            }
        } else
        {
            if (doNow)
            {
                doNow = false;
                GetComponent<Rigidbody>().AddForce(force, fMode);
            }
        }
    }
}
