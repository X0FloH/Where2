using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScanner : MonoBehaviour {

    public float xTarget;
    public GameObject player;
    public GameObject fallCam;
    public Finished finishAnim;

    public List<GameObject> lights = new List<GameObject>();

    public bool done;

    private void Update()
    {
        if (!done)
        {
            if(player.transform.position.x <= xTarget)
            {
                done = true;
                fallCam.SetActive(true);
                player.SetActive(false);
                InvokeRepeating("Checking", 0.01f, Time.deltaTime);
            }
        }
    }

    void Checking()
    {
        if (finishAnim.finished)
        {
            fallCam.SetActive(false);
            player.SetActive(true);
        }
    }
}
