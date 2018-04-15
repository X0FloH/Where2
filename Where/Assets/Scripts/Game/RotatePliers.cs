using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotatePliers : MonoBehaviour {

    public GameObject handle;

    public Vector3 rot;

    private void Update()
    {
        Quaternion tempRot = handle.transform.localRotation;
        tempRot.eulerAngles = rot;
        handle.transform.localRotation = tempRot;
    }
}
