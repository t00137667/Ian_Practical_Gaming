using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControlScript : MonoBehaviour {

    Vector3 Vector3 = new Vector3();
    float turningSpeed;
    float rotateSpeed;
    float speedAdjust;

    // Use this for initialization
    void Start () {
		//GameObject gameObject = new GameObject()
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Implement Swaying Based On MouseInput
    /// </summary>
    /// <param name="horizontalAxis">Mouse Input For Horizontal Rotation</param>
    private void Swaying(double horizontalAxis)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Alter the currentSpeed
    /// </summary>
    private void Accelerate(float speedAdjust)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Determines rotation
    /// </summary>
    private void Rotate(float turnSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Rotates the character Clockwise horizontally
    /// </summary>
    /// <param name="turnSpeed">Rate of Turn</param>
    private void RotateClockwise(float turnSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Rotates the character ClockwiseRotates the character Anti-Clockwise horizontally
    /// </summary>
    private void RotateAntiClockwise(float turningSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Rotates the character Clockwise vertically
    /// </summary>
    private void SpinClockwise(float rotateSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Rotates the character Anti-Clockwise vertically
    /// </summary>
    private void SpinAntiClockwise(string rotateSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Fires the selected weapon
    /// </summary>
    private void FireWeapon()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Iterates through the availiable weapons
    /// </summary>
    private void SelectWeapon()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Use Special Item
    /// </summary>
    private void FireSpecial()
    {
        throw new System.NotImplementedException();
    }
}
