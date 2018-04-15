using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RenderLines : MonoBehaviour {

	void Update () {
        PathFollow followPathScript = GetComponent<PathFollow>();
        List<GameObject> trPoints = new List<GameObject>();
        foreach (GameObject tr in followPathScript.targetTrans)
        {
            trPoints.Add(tr);
        }
        for (int i = 0; i < trPoints.Count; i++)
        {
            print(trPoints.Count.ToString());
            print(i.ToString());
            if (i != 0)
            {
                Debug.DrawLine(trPoints[i-1].transform.position, trPoints[i].transform.position, Color.blue, 0.01f);
            }
            if (i + 1 == trPoints.Count && followPathScript.loop)
            {
                Debug.DrawLine(trPoints[i].transform.position, trPoints[0].transform.position, Color.red, 0.01f);
            }
        }

    }

    private void OnDrawGizmos()
    {
        PathFollow followPathScript = GetComponent<PathFollow>();
        List<GameObject> trPoints = new List<GameObject>();
        Gizmos.color = Color.green;
        foreach (GameObject tr in followPathScript.targetTrans)
        {
            trPoints.Add(tr);
        }
        for (int i = 0; i < trPoints.Count; i++)
        {
            print(trPoints.Count.ToString());
            print(i.ToString());
            Gizmos.DrawSphere(trPoints[i].transform.position, .1f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(trPoints[i].transform.position, followPathScript.detectionRange);
            //Gizmos.DrawSphere(new Vector3(trPoints[i].transform.position.x, trPoints[i].transform.position.y + followPathScript.detectionRange, trPoints[i].transform.position.z), .2f);
        }
    }
}
