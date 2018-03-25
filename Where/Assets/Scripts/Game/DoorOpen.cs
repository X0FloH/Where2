using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public bool openNow;
    public bool closeNow;
    public bool opened;
    public bool stop;
    public bool hasNeededKey;
    public bool hasOpened;
    public bool needsKey;
    public float yTarget = -90f;
    public float speed = 0.001f;
    public Keys playerKeys;
    public string keyName = "Cell";

    private void Update()
    {
        if (keyName != "None")
        {
            if(keyName == "Cell")
            {
                if (playerKeys.hasCellKey)
                {
                    hasNeededKey = true;
                } else
                {
                    hasNeededKey = false;
                }
            }
        }
        if (hasNeededKey || !needsKey) {
            if (stop)
            {
                CancelInvoke();
                stop = false;
            }
            if (openNow)
            {
                hasOpened = true;
                openNow = false;
                opened = true;
                InvokeRepeating("OpenDoor", 0.1f, Time.deltaTime);
            }
            if (closeNow)
            {
                opened = false;
                closeNow = false;
                InvokeRepeating("CloseDoor", 0.1f, Time.deltaTime);
            }
        } else
        {
            openNow = false;
            closeNow = false;
            stop = false;
        }

    }

    void OpenDoor()
    {
        if (yTarget < 0f)
        {
            print(transform.rotation.y);
            if(transform.rotation.y > yTarget)
            {
                Quaternion tempRot = transform.rotation;
                tempRot.y -= speed;
                transform.rotation = tempRot;
            } else
            {
                CancelInvoke();
            }
        }
    }

    void CloseDoor()
    {
       print(transform.localRotation.y);
       if (transform.localRotation.y < 0f)
       {
          Quaternion tempRot = transform.rotation;
          tempRot.y += speed;
          transform.rotation = tempRot;
       }
        else
       {
            CancelInvoke();
       }
    }
}
