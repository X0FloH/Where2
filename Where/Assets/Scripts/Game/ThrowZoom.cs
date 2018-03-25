using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThrowZoom : MonoBehaviour {

    public GameObject guard;
    public Transform focusPoint;
    public float zPos = -5.37f;

    public float slowSpeed = 0.35f;

    public GameObject player;

    Vector3 playerPos;
    bool walkedOver;

    private void FixedUpdate()
    {
        
        if (guard.transform.localPosition.z >= zPos)
        {
            if(guard.GetComponent<Die>().dead == false)
            {
                transform.LookAt(focusPoint);
                player.GetComponent<FirstPersonController>().enabled = false;
                Time.timeScale = slowSpeed;
            } else
            {
                player.GetComponent<FirstPersonController>().enabled = true;
                Time.timeScale = 1f;
            }
        }
    }
}
