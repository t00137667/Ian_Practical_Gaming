using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    Vector3 Offset;
    bool firstTime = true;
    Vector3 targetPosition;
    Quaternion targetOrientation;
    float focusDistance = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.08f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientation, 0.05f);
		
	}

    internal void updatePosition(Transform ship)
    {
      if (firstTime)
        { Offset = transform.position - ship.position;
            firstTime = false;
        }


        targetPosition = ship.position + ship.forward * Offset.z + Offset.y * Vector3.up;
        Vector3 shipFocus = ship.position + focusDistance * ship.forward;
        targetOrientation = Quaternion.LookRotation((shipFocus - targetPosition).normalized);
    }
}
