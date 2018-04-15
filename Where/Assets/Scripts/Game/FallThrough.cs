using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThrough : MonoBehaviour {

    public float xTarget;
    public GameObject player;
    public GameObject fallCam;
    public GameObject torch;
    public Keys playerKeys;

    bool done;

    private void Update()
    {
        if (player.transform.position.x <= xTarget && !done)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            Time.timeScale = 0.15f;
            fallCam.SetActive(true);
            player.SetActive(false);
            if (playerKeys.hasTorch)
            {
                torch.SetActive(true);
            }
            done = true;
        }
    }
}
