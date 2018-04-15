using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFocus : MonoBehaviour {

    public FollowOffset follow;
    public Transform guardTarget;
    public float divide = 4f;

    private void FixedUpdate()
    {
        follow.offset.z = (guardTarget.position.z - transform.position.z) / divide;
    }
}
