using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItems : MonoBehaviour {

    public float detectionRange;

    public Text nameText;

    public Keys gameKeys;

    private void Update()
    {
        nameText.text = "";
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, detectionRange))
        {
            if (hit.transform.tag == "CellKey")
            {
                nameText.text = "Pick Up Cell Key (Left Click)";
                if (Input.GetMouseButtonDown(0))
                {
                    gameKeys.hasCellKey = true;
                    Destroy(hit.transform.gameObject);


                }
            }
            if (hit.transform.tag == "Door")
            {
                if(hit.transform.parent.transform.GetComponent<DoorOpen>().opened == false)
                {
                    nameText.text = "Open Door (Left Click)";
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.parent.transform.GetComponent<DoorOpen>().stop = true;
                        hit.transform.parent.transform.GetComponent<DoorOpen>().openNow = true;
                    }
                }
                else if (hit.transform.parent.transform.GetComponent<DoorOpen>().opened == true)
                {
                    nameText.text = "Close Door (Left Click)";
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.parent.transform.GetComponent<DoorOpen>().stop = true;
                        hit.transform.parent.transform.GetComponent<DoorOpen>().closeNow = true;
                    }
                }
            }
        }
    }
}
