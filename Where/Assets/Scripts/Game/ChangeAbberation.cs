using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAbberation : MonoBehaviour {

    public Material abbMat;

    [Range(-0.5f, 0.5f)]
    public float redX;
    [Range(-0.5f, 0.5f)]
    public float redY;
    [Range(-0.5f, 0.5f)]
    public float greenX;
    [Range(-0.5f, 0.5f)]
    public float greenY;
    [Range(-0.5f, 0.5f)]
    public float blueX;
    [Range(-0.5f, 0.5f)]
    public float blueY;

    private void Update()
    {
        abbMat.SetFloat("_RedX", redX);
        abbMat.SetFloat("_RedY", redY);
        abbMat.SetFloat("_GreenX", greenX);
        abbMat.SetFloat("_GreenY", greenY);
        abbMat.SetFloat("_BlueX", blueX);
        abbMat.SetFloat("_BlueY", blueY);
    }
}
