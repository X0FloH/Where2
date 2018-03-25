using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {

    public DoorOpen door;
    public List<GameObject> lights = new List<GameObject>();

    private void Update()
    {
        if (door.hasOpened)
        {
            foreach(GameObject light in lights)
            {
                light.SetActive(true);
            }
        } else
        {
            foreach(GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
