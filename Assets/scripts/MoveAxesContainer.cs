using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxesContainer 
{
    private Vector3 currentVeloticity = Vector3.zero;

    private MoveAxisController horizontal;
    private MoveAxisController vertical;
    private MoveAxisController forward;

    public MoveAxisController Horizontal { get => horizontal; set => horizontal = value; }
    public MoveAxisController Vertical { get => vertical; set => vertical = value; }
    public MoveAxisController Forward { get => forward; set => forward = value; }
    public Vector3 CurrentVeloticity { get => currentVeloticity; set => currentVeloticity = value; }

    public void AccelerateHorizontal(float inputAcceleration, float deltaTime)
    {
        Horizontal.Accelerate(inputAcceleration, deltaTime);
        this.currentVeloticity.x = Horizontal.CurrentVelocity;
    }

    public void AccelerateVertical(float inputAcceleration, float deltaTime)
    {
        Vertical.Accelerate(inputAcceleration, deltaTime);
        this.currentVeloticity.y = Vertical.CurrentVelocity;
    }

    public void AccelerateForward(float inputAcceleration, float deltaTime)
    {
        Forward.Accelerate(inputAcceleration, deltaTime);
        this.currentVeloticity.z = Forward.CurrentVelocity;
    }
}
