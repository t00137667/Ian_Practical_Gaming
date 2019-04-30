using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControlScript : MonoBehaviour {

    public bool isPlayerShip = false;

    public enum ShipMovement { Normal, Rolling_Left, Rolling_Right}

    public ShipMovement shipIs = ShipMovement.Normal;
    private float rollTimer;
    private float scriptTimer = 0;
    float time = 0;
    float turningSpeed;
    float rotateSpeed = 2.0f;
    float speedAdjust = 5f;
    float maxSpeed = 50f;
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
        if (isPlayerShip)
        {
            ourCamera = Camera.main.GetComponent<CameraControl>();
        }
        
        Quaternion levelQuaternion = transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {

        if (isPlayerShip)
        {
            switch (shipIs)
            {
                case ShipMovement.Normal:

                    // Get the horizontal and vertical axis.
                    // By default they are mapped to the arrow keys.
                    // The value is in the range -1 to 1
                    float rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                    rotation *= Time.deltaTime;


                    // Calculate a banking angle
                    float bank = Input.GetAxis("Mouse X") * rotateSpeed;

                    //Try prevent extreme rotations
                    if (Vector3.Dot(Vector3.up, transform.up) < 0)
                        bank = 0;
                    // Rotate around our y-axis
                    transform.Rotate(0, rotation, 0, Space.World);

                    //Set up a level rotation to rotate back to
                    Quaternion level = Quaternion.LookRotation(transform.forward, Vector3.up);

                    //bank the ship
                    transform.Rotate(0, 0, -bank);

                    if (Input.GetAxis("Mouse X") == 0 && (Mathf.Abs(transform.rotation.eulerAngles.z) > 0 || Mathf.Abs(transform.rotation.eulerAngles.z) < 0))
                    {
                        time += Time.deltaTime;
                        //Debug.Log(time);
                        if (time > 1) { time = 0.0f; }
                        transform.rotation = Quaternion.Lerp(transform.rotation, level, 0.05f);
                    }
                    
                    scriptTimer += Time.deltaTime;
                    ShouldMove();
                    if (ourCamera != null)
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
                    ourCamera.updatePosition(transform);
                    break;



                case ShipMovement.Rolling_Left:

                    SpinAntiClockwise(rollSpeed);
                    ourCamera.updatePosition(transform);
                    break;

            }
        }
        else
        {
            if (true)
            {

            }


            ShouldMove();
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
        if (speed >= maxSpeed && speedAdjust > 0)
        {
            return;
        }
        if (speed <= 5 && speedAdjust < 0 && isPlayerShip)
        {
            return;
        }
        if (speed <= 0 && speedAdjust < 0)
        {
            speed = 0;
        }
        else
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
        if (ShouldAccelerate() && isPlayerShip)
        {
            //Debug.Log("Accelerating");
            //Debug.Log("Current Speed: " + speed);
            Accelerate(speedAdjust);

        }
        if (ShouldDeccelerate() && isPlayerShip)
        {
            //Debug.Log("Deccelerating");
            //Debug.Log("Current Speed: " + speed);
            Accelerate(-speedAdjust);
        }
        if (ShouldStrafeLeft() && isPlayerShip)
        {
            //Debug.Log("Strafing Left");
            transform.position -= transform.right * strafeSpeed *Time.deltaTime;

        }
        if (ShouldStrafeRight() && isPlayerShip)
        {
            //Debug.Log("Strafing Right");
            transform.position += transform.right * strafeSpeed * Time.deltaTime;
        }
        if (ShouldRollLeft() && isPlayerShip)
        {
            shipIs = ShipMovement.Rolling_Left;
            rollTimer = 0;
            startingPosition = transform.position;
            //SpinAntiClockwise(rotateSpeed);
        }
        if (ShouldRollRight() && isPlayerShip)
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
