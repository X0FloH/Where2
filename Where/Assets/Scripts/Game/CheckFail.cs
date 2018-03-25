using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFail : MonoBehaviour {

    public float xDetect;
    public FadeOutBlack fadeOutBlack;
    public GameObject player;
    public DoorOpen door;

    bool done;

    private void Update()
    {
        if (!done && player.transform.position.x > xDetect)
        {
            if (door.opened == false)
            {
                if (transform.position.x <= xDetect)
                {
                    fadeOutBlack.now = true;
                    done = true;
                }
            }
        }

    }
}
