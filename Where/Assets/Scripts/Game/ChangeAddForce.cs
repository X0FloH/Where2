using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAddForce : MonoBehaviour {

    public bool doNow;
    public AddForce aForce;

    private void Update()
    {
        aForce.doNow = doNow;
    }
}
