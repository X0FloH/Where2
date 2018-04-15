using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWire : MonoBehaviour {

    public Animator wireAnim;

    bool done;

    private void Update()
    {
        if (!done)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                wireAnim.SetBool("Choose1", true);
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                wireAnim.SetBool("Choose2", true);
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                wireAnim.SetBool("Choose3", true);
                done = true;
            }
        }
    }
}
