using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Rendering;

public class BreakScanner : MonoBehaviour {

    public float xTarget;
    public GameObject player;
    public GameObject newPlayer;
    public GameObject fallCam;
    public Renderer greenLight;
    public Material nonLit;
    public GameObject flare1;
    public GameObject flare2;
    public GameObject scannerColObj;

    public Finished finishAnim;

    public float endingX;

    public List<GameObject> lights = new List<GameObject>();

    public bool done;

    private void Update()
    {
        if (!done)
        {
            if(player.transform.position.x <= xTarget)
            {
                done = true;
                foreach(GameObject light in lights)
                {
                    light.SetActive(false);
                }
                greenLight.material = nonLit;
                flare1.SetActive(true);
                flare2.SetActive(true);
                player.GetComponent<FirstPersonController>().m_YRotation = 0f;
                Vector3 temp = player.transform.localPosition;
                temp.x = endingX;
                player.transform.localPosition = temp;
                Quaternion temp2 = player.transform.rotation;
                temp2.y = -90.00001f;
                player.transform.rotation = temp2;
                player.transform.GetChild(0).transform.rotation = Quaternion.identity;
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
            newPlayer.SetActive(true);
            scannerColObj.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
