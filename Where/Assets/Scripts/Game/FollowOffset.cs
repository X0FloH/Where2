using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOffset : MonoBehaviour {

    public Vector3 offset;
    public Transform target;

    public bool local;

    private void Update()
    {
        if (!local)
        {
            transform.position = target.position + offset;
        } else
        {
            transform.localPosition = target.localPosition + offset;
        }
    }
}
