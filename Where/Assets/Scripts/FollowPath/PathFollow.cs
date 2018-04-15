using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {

    public List<GameObject> targetTrans = new List<GameObject>();

    [Header("Options")]
    public float speed = .04f;
    public float turnDamping = 1f;
    public bool loop;
    public bool allowUpwardsMotion;
    public float detectionRange;

    [Header("Script Controlled")]
    public int currentPlace = -1;
    public GameObject oldNode;

    private void Update()
    {
        if (!allowUpwardsMotion)
        {
            var lookPos = targetTrans[currentPlace + 1].transform.position - transform.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnDamping);
        } else
        {
            var lookPos = targetTrans[currentPlace + 1].transform.position - transform.transform.position;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnDamping);
        }
        CharacterController cC = GetComponent<CharacterController>();
        if (cC)
        {
            cC.Move(transform.forward * speed);
        }
        print((currentPlace + 1).ToString());
        if (!allowUpwardsMotion && transform.transform.position == targetTrans[currentPlace + 1].transform.transform.position || (transform.transform.position.x < targetTrans[currentPlace + 1].transform.position.x + detectionRange && transform.transform.position.x > targetTrans[currentPlace + 1].transform.position.x - detectionRange && transform.transform.position.z < targetTrans[currentPlace + 1].transform.position.z + detectionRange && transform.transform.position.z > targetTrans[currentPlace + 1].transform.position.z - detectionRange))
        {
            if (currentPlace + 2 == targetTrans.Count && loop)
            {
                currentPlace = -1;
            }
            else
            {
                currentPlace += 1;
            }
        } else if (allowUpwardsMotion && transform.transform.position == targetTrans[currentPlace + 1].transform.transform.position || (transform.transform.position.x < targetTrans[currentPlace + 1].transform.position.x + detectionRange && transform.transform.position.x > targetTrans[currentPlace + 1].transform.position.x - detectionRange && transform.transform.position.z < targetTrans[currentPlace + 1].transform.position.z + detectionRange && transform.transform.position.z > targetTrans[currentPlace + 1].transform.position.z - detectionRange && transform.transform.position.y < targetTrans[currentPlace + 1].transform.position.y + detectionRange && transform.transform.position.y > targetTrans[currentPlace + 1].transform.position.y - detectionRange))
        {
            if (currentPlace + 2 == targetTrans.Count && loop)
            {
                currentPlace = -1;
            }
            else
            {
                currentPlace += 1;
            }
        }
        detectionRange = Mathf.Clamp(detectionRange, 0.5f, 5f);
    }

}
