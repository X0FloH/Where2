using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

    public Transform target;

    private void FixedUpdate()
    {
        gameObject.transform.LookAt(target.position);
    }
}
