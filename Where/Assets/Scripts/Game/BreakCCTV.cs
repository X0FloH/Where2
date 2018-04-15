using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakCCTV : MonoBehaviour {

    public float detectionRange = 3f;

    public Text nameText;

    public GameObject cctv1Cam;
    public GameObject worldPliers;

    public bool brokenCCTV1;

    private void LateUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, detectionRange))
        {
            if(hit.transform.tag == "CCTV1Break")
            {
                if(brokenCCTV1 == false)
                {
                    nameText.text = "Break CCTV 1 (Left Click)";
                }
                if (Input.GetMouseButtonDown(0) && !brokenCCTV1)
                {
                    cctv1Cam.SetActive(true);
                    worldPliers.SetActive(false);
                    brokenCCTV1 = true;
                    nameText.text = "";
                    gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }
}
