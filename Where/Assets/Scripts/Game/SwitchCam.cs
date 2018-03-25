using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour {

    public GameObject player;

    bool done;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!done)
        {
            if(GetComponent<Finished>().finished == true)
            {
                done = true;
                player.SetActive(true);
                gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && GetComponent<FadeIn>().readyNow)
            {
                done = true;
                player.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
