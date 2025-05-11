using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisController 
{
    private float currentVelocity = 0;
    private float acceleration;
    private float maxVelocity;
    private float fricction = 0;
    private float toleranceEpsilon = 0.01f;

    public float CurrentVelocity { get => currentVelocity; set => currentVelocity = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }
    public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
    public float Fricction { get => fricction; set => fricction = value; }
    public float ToleranceEpsilon { get => toleranceEpsilon; set => toleranceEpsilon = value; }

    public void Accelerate(float inputAcceleration, float deltaTime) 
    {   

        float f = MoveAxisController.CalcFricction(this.Fricction, this.CurrentVelocity, inputAcceleration, deltaTime);
        float a = (this.Acceleration * inputAcceleration) * deltaTime;
        a = this.CurrentVelocity + a + f;
        a = a > (-1) * this.ToleranceEpsilon && a < this.ToleranceEpsilon ? 0 : a;
        this.CurrentVelocity = Mathf.Clamp(a, (-1) * this.MaxVelocity, this.MaxVelocity);
    }

    public static float CalcFricction(float axisFricction, float currentVelocity, float inputAcceleration, float deltaTime)
    {
        float fricction = 0;
        if (inputAcceleration == 0 && currentVelocity != 0)
        {
            fricction = axisFricction * deltaTime;
            fricction = currentVelocity > 0 ? (-1) * fricction : fricction;
        }
        return fricction;
    }
}
