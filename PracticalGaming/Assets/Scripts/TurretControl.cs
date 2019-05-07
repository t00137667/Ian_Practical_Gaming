using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour {

    Transform turretTarget, leftArm, leftShoulder, rightArm, rightShoulder, centralColumn;
    
    // Use this for initialization
	void Start () {
        // HindSight is 20/20, should have renamed the bones in 3ds Max
        rightShoulder = GetComponent<Transform>().Find("Bone007/Bone002/Bone001");
        rightArm = GetComponent<Transform>().Find("Bone003");
        leftShoulder = GetComponent<Transform>().Find("Bone004");
        leftArm = GetComponent<Transform>().Find("Bone006");
        centralColumn = GetComponent<Transform>().Find("Bone007");
	}
	
	// Update is called once per frame
	void Update () {
		if (rightShoulder == null)
        {
            Debug.Log("Right Shoulder is null");
        }
        else
        {
            Debug.Log("Right Shoulder Found");
        }
	}
}
