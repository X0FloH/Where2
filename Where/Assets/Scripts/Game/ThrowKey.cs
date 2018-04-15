using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKey : MonoBehaviour {

    public Keys keys;
    public DoorOpen door;
    public FadeOutBlack fadeOut;
    public GameObject cellKey;
    public GameObject torch;

    public float throwForce = 0.5f;

    void Update()
    {
        if (keys.hasCellKey)
        {
            if (Input.GetMouseButtonDown(1))
            {
                keys.hasCellKey = false;
                GameObject newKey = Instantiate(cellKey, transform.position + (transform.forward*2), transform.rotation);
                newKey.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                newKey.GetComponent<CheckFail>().fadeOutBlack = fadeOut;
                newKey.GetComponent<CheckFail>().player = gameObject.transform.parent.gameObject;
                newKey.GetComponent<CheckFail>().door = door;
            }
        }
        if (keys.hasTorch)
        {
            if (Input.GetMouseButtonDown(1))
            {
                keys.hasTorch = false;
                GameObject newKey = Instantiate(torch, transform.position + (transform.forward * 2), transform.rotation);
                newKey.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            }
        }
    }
}
