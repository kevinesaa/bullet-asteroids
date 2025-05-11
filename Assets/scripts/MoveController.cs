using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("move setting")]
    #region move settings

    public Vector3 rotationsPerSeconds;
    public Vector3 accelerations;
    public Vector3 maxVelocities;
    public Vector3 fricctions;
    #endregion
    
    public float toleranceEpsilon;



    private Rigidbody myRigidbody;
    private MoveAxesContainer moveAxesContainer;

    private Vector3 accelerationInputs;
    private Vector3 rotationsInput;
    private Vector3 rotationState;
    

    private void Awake()
    {
        this.myRigidbody = GetComponent<Rigidbody>();
        this.rotationsInput = Vector3.zero;
        this.rotationState = Vector3.zero;

        MoveAxisController horizontal = new MoveAxisController();
        horizontal.Acceleration = this.accelerations.x;
        horizontal.Fricction = this.fricctions.x;
        horizontal.MaxVelocity = this.maxVelocities.x;
        horizontal.ToleranceEpsilon = this.toleranceEpsilon;

        MoveAxisController vertical = new MoveAxisController();
        vertical.Acceleration = this.accelerations.y;
        vertical.Fricction = this.fricctions.y;
        vertical.MaxVelocity = this.maxVelocities.y;
        vertical.ToleranceEpsilon = this.toleranceEpsilon;

        MoveAxisController forward = new MoveAxisController();
        forward.Acceleration = this.accelerations.z;
        forward.Fricction = this.fricctions.z;
        forward.MaxVelocity = this.maxVelocities.z;
        forward.ToleranceEpsilon = this.toleranceEpsilon;
        
        this.moveAxesContainer = new MoveAxesContainer();
        this.moveAxesContainer.Horizontal = horizontal;
        this.moveAxesContainer.Vertical = vertical;
        this.moveAxesContainer.Forward = forward;
    }


    

    // Update is called once per frame
    void Update()
    {

        this.accelerationInputs.x = Input.GetAxisRaw("accelerate_horizontal");
        this.accelerationInputs.y = Input.GetAxisRaw("accelerate_vertical");
        this.accelerationInputs.z = Input.GetAxisRaw("accelerate_forward");
        
        this.rotationsInput.x = Input.GetAxis("vertical_rotation");
        this.rotationsInput.y = Input.GetAxis("horizontal_rotation");
        this.rotationsInput.z = Input.GetAxis("z_axis_rotation");

        Accelerate();
        MyRotation();
    }

    public void Accelerate()
    {
        float dt = Time.deltaTime;
        this.moveAxesContainer.CurrentVeloticity = this.myRigidbody.velocity;
        this.moveAxesContainer.AccelerateHorizontal(this.accelerationInputs.x, dt);
        this.moveAxesContainer.AccelerateVertical(this.accelerationInputs.y, dt);
        this.moveAxesContainer.AccelerateForward(this.accelerationInputs.z, dt);
        this.myRigidbody.velocity = this.moveAxesContainer.CurrentVeloticity;
    }
    

    public void MyRotation() 
    {
        this.rotationState.x = this.rotationsPerSeconds.x * this.rotationsInput.x;
        this.rotationState.y = this.rotationsPerSeconds.y * this.rotationsInput.y;
        this.rotationState.z = this.rotationsPerSeconds.z * this.rotationsInput.z;
        this.rotationState = this.rotationState * Time.deltaTime;
        
        this.transform.Rotate(this.rotationState);
    }
}
