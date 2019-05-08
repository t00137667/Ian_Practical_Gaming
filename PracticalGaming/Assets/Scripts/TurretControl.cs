using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour {


    GameManagerScript myManager;
    GameObject turretTarget, leftArm, leftShoulder, rightArm, rightShoulder, centralColumn;
    WeaponControl myWeaponControl;

    Vector3 baseRotation, armRotation;
    
    // Use this for initialization
	void Start () {

        myManager = FindObjectOfType<GameManagerScript>();
        myWeaponControl = GetComponentInChildren<WeaponControl>();

        // HindSight is 20/20, should have renamed the bones in 3ds Max
        rightShoulder = GameObject.Find("Bone001");
        //rightArm = GetComponent<Transform>().Find("Bone003");
        leftShoulder = GameObject.Find("Bone004");
        //leftArm = GetComponent<Transform>().Find("Bone006");
        centralColumn = GameObject.Find("Bone007");
	}
	
	// Update is called once per frame
	void Update () {
		if (turretTarget == null)
        {
            myManager.ProvideTarget(gameObject);
        }
        
    }

    private void LateUpdate()
    {
        float yRotation = 45 * Time.deltaTime;

        Vector3 rotation = new Vector3(0, yRotation, 0);

        centralColumn.transform.eulerAngles = rotation;
        rightShoulder.transform.eulerAngles = rotation;
        leftShoulder.transform.eulerAngles = rotation;
    }

    public void SetTarget(GameObject target)
    {
        turretTarget = target;
    }
}
