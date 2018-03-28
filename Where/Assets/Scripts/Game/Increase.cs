using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Increase : MonoBehaviour {

    public float xTarget;
    public int nextLevel;
    public GameObject player;

    private void Update()
    {
        if(player.transform.position.x <= xTarget)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
