using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

    public List<string> tags = new List<string>();

    public bool dead;

    private void OnTriggerEnter(Collider collision)
    {
        foreach(string tag in tags)
        {
            if(collision.transform.tag == tag)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                dead = true;
            }
        }
    }
}
