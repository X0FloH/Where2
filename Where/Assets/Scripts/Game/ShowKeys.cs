using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeys : MonoBehaviour {

    public Keys keys;

    public GameObject cellKey;
    public GameObject torch;

    private void Update()
    {
        cellKey.SetActive(keys.hasCellKey);
        torch.SetActive(keys.hasTorch);
    }
}
