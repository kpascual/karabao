using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CarControllerMulti : NetworkBehaviour
{
    public List<AxleInfoMulti> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private bool isControlExternal;
    private float motor = 0;
    private float steering = 0;
        
    public void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            // Handle steering and throttle
            float[] controls = GetSteeringAndThrottle();
                
            foreach (AxleInfoMulti axleInfo in axleInfos) {
                if (axleInfo.steering) {
                    axleInfo.leftWheel.steerAngle = controls[1];
                    axleInfo.rightWheel.steerAngle = controls[1];
                }
                if (axleInfo.motor) {
                    axleInfo.leftWheel.motorTorque = controls[0];
                    axleInfo.rightWheel.motorTorque = controls[0];
                }
            }

        }
    }

    public void ListenExternalControlCommands(float receivedThrottle, float receivedSteering) {
        if (isControlExternal) {
            motor = receivedThrottle;
            steering = receivedSteering;
        }
    }

    private float[] GetSteeringAndThrottle()
    {
        float newMotor;
        float newSteering;

        if (isControlExternal)
        {
            newMotor = maxMotorTorque * motor;
            newSteering = maxSteeringAngle * steering;
        } else {
            newMotor = maxMotorTorque * Input.GetAxis("Vertical");
            newSteering = maxSteeringAngle * Input.GetAxis("Horizontal");
        }

        return new float[2] {newMotor, newSteering};
    }

    public void SetControl(bool isExternal)
    {
        isControlExternal = isExternal;
        Debug.Log("control changed");
        Debug.Log(isControlExternal);
    }
}

[System.Serializable]
public class AxleInfoMulti {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}