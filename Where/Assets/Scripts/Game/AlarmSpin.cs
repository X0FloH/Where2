using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSpin : MonoBehaviour {

    public float speed = 2f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
