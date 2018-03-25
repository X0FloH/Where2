using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDoorOpen : MonoBehaviour {

    public float zDetect;
    public GameObject guard;
    public DoorOpen door;

    bool opened;

    private void Update()
    {
        if (!opened)
        {
            if(guard.transform.localPosition.z >= zDetect)
            {
                door.openNow = true;
                opened = true;
            }
        }
    }
}
