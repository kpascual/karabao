using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CarControllerMulti : NetworkBehaviour
{
    public List<AxleInfoMulti> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
        
    public void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
                
            foreach (AxleInfoMulti axleInfo in axleInfos) {
                if (axleInfo.steering) {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor) {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }

        }
    }
}

[System.Serializable]
public class AxleInfoMulti {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}