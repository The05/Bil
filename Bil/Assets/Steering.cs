using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;

    void Update()
    {
        float steerAngle = 0f;
        float motor = 0f;
        float breakTorque = 0f;

        if ( Input.GetKey(KeyCode.W))
        {
            motor += 2000f;
        }
        if ( Input.GetKey(KeyCode.S))
        {
            breakTorque += 10000f;
        }
        if (Input.GetKey(KeyCode.D)){
            steerAngle += 40f;
        }if (Input.GetKey(KeyCode.A)){
            steerAngle -= 40f;
        }

        FL.steerAngle = steerAngle;
        FR.steerAngle = steerAngle;
        RL.motorTorque = motor;
        RR.motorTorque = motor;

        FL.brakeTorque = breakTorque;
        FR.brakeTorque = breakTorque;
        RL.brakeTorque = breakTorque;
        RR.brakeTorque = breakTorque;

    }
}
