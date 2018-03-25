using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public GameObject playCam;
    public GameObject fadeCam;

    public float killHeight;

    private void Update()
    {
        if(gameObject.transform.position.y <= killHeight)
        {
            playCam.GetComponent<FadeOutBlack>().now = true;
            fadeCam.GetComponent<FadeIn>().now = false;
        }
    }
}
