using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItems : MonoBehaviour {

    public float detectionRange;

    public Text nameText;

    public Keys gameKeys;

    public bool level2;

    public GameObject ZoomCam;
    public GameObject currentPlayer;

    private void Update()
    {
        nameText.text = "";
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, detectionRange))
        {
            if (hit.transform.tag == "CellKey" && gameKeys.hasTorch == false)
            {
                nameText.text = "Pick Up Cell Key (Left Click)";
                if (Input.GetMouseButtonDown(0))
                {
                    gameKeys.hasCellKey = true;
                    Destroy(hit.transform.gameObject);
                }
            }
            if (hit.transform.tag == "Torch" & gameKeys.hasCellKey == false)
            {
                nameText.text = "Pick Up Torch (Left Click)";
                if (Input.GetMouseButtonDown(0))
                {
                    gameKeys.hasTorch = true;
                    Destroy(hit.transform.gameObject);
                }
            }
            if(hit.transform.tag == "Grate" && level2)
            {
                nameText.text = "Go Into Grate (Left Click)";
                if (Input.GetMouseButtonDown(0))
                {
                    ZoomCam.transform.position = currentPlayer.GetComponent<Transform>().position;
                    ZoomCam.transform.rotation = currentPlayer.GetComponent<Transform>().rotation;
                    ZoomCam.SetActive(true);
                    currentPlayer.SetActive(false);
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
