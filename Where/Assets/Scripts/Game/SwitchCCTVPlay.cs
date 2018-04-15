using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCCTVPlay : MonoBehaviour {

    public GameObject player;

    private void Update()
    {
       if(GetComponent<Finished>().finished == true)
        {
            player.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
