using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    public float yCrouchHeight;
    public float yNormalHeight;
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 newPos = transform.localPosition;
            newPos.y = Mathf.Lerp(newPos.y, yCrouchHeight, speed * Time.deltaTime);
            transform.localPosition = newPos;
        } else
        {
            Vector3 newPos = transform.localPosition;
            newPos.y = Mathf.Lerp(newPos.y, yNormalHeight, speed * Time.deltaTime);
            transform.localPosition = newPos;
        }
    }
}
