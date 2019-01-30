using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControlScript : MonoBehaviour {

    Vector3 velocity = new Vector3();
    float turningSpeed;
    float rotateSpeed = 100.0f;
    float speedAdjust;
    float acceleration = 2f;

    //Declare Keys


    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;


    // Use this for initialization
    void Start () {
        Debug.Log("I liiiive!");
	}
	
	// Update is called once per frame
	void Update () {
        //Quick Implement Code to demonstrate movement

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * 0.5f;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        ShouldMove();
        
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
    private void SpinAntiClockwise(float rotateSpeed)
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

    /// <summary>
    /// Checks if the character should implement movement
    /// </summary>
    private void ShouldMove()
    {
        //throw new System.NotImplementedException();
        if (ShouldAccelerate())
        {
            Debug.Log("Acceleratiing");
        }
        if (ShouldDeccelerate())
        {
            Debug.Log("Deccelerating");
        }
        if (ShouldStrafeLeft())
        {
            Debug.Log("Strafing Left");
        }
        if (ShouldStrafeRight())
        {
            Debug.Log("Strafing Right");
        }
        if (ShouldRollLeft())
        {
            SpinAntiClockwise(rotateSpeed);
        }
        if (ShouldRollRight())
        {
            SpinClockwise(rotateSpeed);
        }
    }

    /// <summary>
    /// Checks if the character should accelerate
    /// </summary>
    private bool ShouldAccelerate()
    {
        if (Input.GetAxis("Vertical") > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks if the character should deccelerate
    /// </summary>
    private bool ShouldDeccelerate()
    {
        if (Input.GetAxis("Vertical") < 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks if the character should strafe left
    /// </summary>
    private bool ShouldStrafeLeft()
    {
        if (Input.GetAxis("Horizontal") < 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks if the character should strafe right
    /// </summary>
    private bool ShouldStrafeRight()
    {
        if (Input.GetAxis("Horizontal") > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks if the character should roll left
    /// </summary>
    private bool ShouldRollLeft()
    {
        if (Input.GetKeyDown("q"))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks if the character should roll right
    /// </summary>
    private bool ShouldRollRight()
    {
        if (Input.GetKeyDown("e"))
            return true;
        else
            return false;
    }
}
