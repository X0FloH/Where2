using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFocus : MonoBehaviour {

    public FollowOffset follow;
    public Transform guardTarget;

    private void Update()
    {
        follow.offset.z = (guardTarget.position.z - transform.position.z) / 4;
    }
}
