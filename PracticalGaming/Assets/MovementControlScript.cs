using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControlScript : MonoBehaviour {
    enum ShipMovement { Normal, Rolling_Left, Rolling_Right}

    ShipMovement shipIs = ShipMovement.Normal;
    private float rollTimer;
    private float scriptTimer = 0;
    float time = 0;
    float turningSpeed;
    float rotateSpeed = 100.0f;
    float speedAdjust = 5f;
    float strafeSpeed = 5f;
    float rollSpeed = 360;
    float rollLateralMovement = 40;
    float rollVerticalMovement = 5;
    //Declare Keys
    CameraControl ourCamera;

    public float speed = 10.0f;
    public float rotationSpeed = 50.0f;
    private int move;
    private float test;
    private Vector3 startingPosition;


    // Use this for initialization
    void Start () {
        Debug.Log("I liiiive!");
        ourCamera = Camera.main.GetComponent<CameraControl>();
        Quaternion levelQuaternion = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {


        switch (shipIs)
        {
            case ShipMovement.Normal:

                

                //Quick Implement Code to demonstrate movement

                // Get the horizontal and vertical axis.
                // By default they are mapped to the arrow keys.
                // The value is in the range -1 to 1
                float translation =  speed;
                float rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                // Make it move 10 meters per second instead of 10 meters per frame...
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;

                // Move translation along the object's z-axis
                transform.Translate(0, 0, translation);

                float bank = rotation;
                if (Mathf.Abs(transform.rotation.eulerAngles.z) > 90)
                    bank = 0;
                // Rotate around our y-axis
                Vector3 left = Vector3.left;
                Vector3 right = Vector3.right;

                transform.Rotate(0, rotation, bank);
                //transform.LookAt(transform.position + transform.forward,   ) ;
                
                if (Input.GetAxis("Mouse X") == 0 && Mathf.Abs(transform.rotation.eulerAngles.z) > 0)
                {
                    Vector3 levelled = transform.forward;
                    levelled.y = 0;
                    time += Time.deltaTime;
                    Debug.Log(time);
                    if (time > 1) { time = 0.0f; }
                    transform.forward = Vector3.Slerp(transform.forward, levelled.normalized, time);
                }
                
                



                scriptTimer += Time.deltaTime;
                ShouldMove();
                ourCamera.updatePosition(transform);

                if (Input.GetKeyDown(KeyCode.P))
                {
                    shipIs = ShipMovement.Rolling_Right;
                    rollTimer = 0;
                    startingPosition = transform.position;
                }
                break;


            case ShipMovement.Rolling_Right:

                SpinClockwise(rollSpeed);
                break;



            case ShipMovement.Rolling_Left:

                SpinAntiClockwise(rollSpeed);
                break;

        }



        
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
        //throw new System.NotImplementedException();
        speed += speedAdjust * Time.deltaTime;
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
    /// Rotates the character Anti-Clockwise horizontally
    /// </summary>
    private void RotateAntiClockwise(float turningSpeed)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Rotates the character Clockwise vertically
    /// </summary>
    private void SpinClockwise(float rollSpeed)
    {
        Vector3 horzPosition = new Vector3(transform.position.x,0,transform.position.z);
        Vector3 verticalPosition = new Vector3(0, startingPosition.y, 0);

        // Caluclate the circular motion of the y axis
        verticalPosition.y = rollVerticalMovement + rollVerticalMovement * Mathf.Sin(Mathf.Deg2Rad * (rollTimer - 90));

        //Need to move the XZ independantly of the Y. transform.right cannot be used because of object rotation
        horzPosition = horzPosition + (transform.forward * speed * Time.deltaTime) + (-transform.right * rollLateralMovement * Time.deltaTime);
        horzPosition.y = 0;
        
        transform.position = horzPosition + verticalPosition;
        
        rollTimer += rollSpeed * Time.deltaTime;
 
        transform.Rotate(Vector3.forward, -rollSpeed * Time.deltaTime, Space.Self);



        if (rollTimer > 360)
        {
            shipIs = ShipMovement.Normal;
            Vector3 ang = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(ang.x, ang.y, 0.0f);
        }
    }

    /// <summary>
    /// Rotates the character Anti-Clockwise vertically
    /// </summary>
    private void SpinAntiClockwise(float rollSpeed)
    {
        Vector3 horzPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 verticalPosition = new Vector3(0, startingPosition.y, 0);

        // Caluclate the circular motion of the y axis
        verticalPosition.y = rollVerticalMovement + rollVerticalMovement * Mathf.Sin(Mathf.Deg2Rad * (rollTimer - 90));

        //Need to move the XZ independantly of the Y. transform.right cannot be used because of object rotation
        horzPosition = horzPosition + (transform.forward * speed * Time.deltaTime) + (transform.right * rollLateralMovement * Time.deltaTime);
        horzPosition.y = 0;

        transform.position = horzPosition + verticalPosition;

        rollTimer += rollSpeed * Time.deltaTime;

        transform.Rotate(Vector3.forward, rollSpeed * Time.deltaTime, Space.Self);



        if (rollTimer > 360)
        {
            shipIs = ShipMovement.Normal;
            Vector3 ang = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(ang.x, ang.y, 0.0f);
        }
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
            //Debug.Log("Accelerating");
            //Debug.Log("Current Speed: " + speed);
            Accelerate(speedAdjust);

        }
        if (ShouldDeccelerate())
        {
            //Debug.Log("Deccelerating");
            //Debug.Log("Current Speed: " + speed);
            Accelerate(-speedAdjust);
        }
        if (ShouldStrafeLeft())
        {
            //Debug.Log("Strafing Left");
            transform.position -= transform.right * strafeSpeed *Time.deltaTime;

        }
        if (ShouldStrafeRight())
        {
            //Debug.Log("Strafing Right");
            transform.position += transform.right * strafeSpeed * Time.deltaTime;
        }
        if (ShouldRollLeft())
        {
            shipIs = ShipMovement.Rolling_Left;
            rollTimer = 0;
            startingPosition = transform.position;
            //SpinAntiClockwise(rotateSpeed);
        }
        if (ShouldRollRight())
        {
            shipIs = ShipMovement.Rolling_Right;
            rollTimer = 0;
            startingPosition = transform.position;
            //SpinClockwise(rotateSpeed);
        }
        Move();
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

    /// <summary>
    /// Implements the moving of the character
    /// </summary>
    private void Move()
    {
        // Move translation along the object's z-axis
        transform.Translate(0, 0, speed * Time.deltaTime);

        // Rotate around our y-axis
        //transform.Rotate(0, rotation, 0);
    }
}
