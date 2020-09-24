using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
    
public class CarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private bool isControlExternal = false;
    private float motor = 0;
    private float steering = 0;
        
    public void FixedUpdate()
    {
        // Handle steering and throttle
        float[] controls = GetSteeringAndThrottle();
            
        foreach (AxleInfo axleInfo in axleInfos) {
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
    
    public void ListenExternalControlCommands(float receivedThrottle, float receivedSteering) {
        if (isControlExternal) {
            motor = receivedThrottle;
            steering = receivedSteering;
        }
    }

    public void SetControl(bool isExternal)
    {
        isControlExternal = isExternal;
        Debug.Log("control changed");
        Debug.Log(isControlExternal);
    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}