using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkIn : MonoBehaviour {

    public DoorOpen door;
    public bool now;
    public float speed = 2f;

    public Transform target;

    bool started;

    private void LateUpdate()
    {
        if(door.hasOpened && !GetComponent<Die>().dead && !started)
        {
            Invoke("StartNow", 2f);
            started = true;
        }
        if (now)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        }
        if (GetComponent<Die>().dead)
        {
            now = false;
        }
    }

    private void StartNow()
    {
        now = true;
    }
}
