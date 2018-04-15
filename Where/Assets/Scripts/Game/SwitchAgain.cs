using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAgain : MonoBehaviour {

    public GameObject secondPlayer;
    public GameObject pliers;

    private void Update()
    {
        if (GetComponent<Finished>().finished)
        {
            secondPlayer.SetActive(true);
            pliers.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
