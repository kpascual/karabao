using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
    
public class CarTelemetry : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public Rigidbody carRigidBody;
    public Text speedText;
    public Text accelerationText;
    public Text rpmsText;

    public Vector3 velocity;
    public Vector3 acceleration;
    public List<int> wheelRpms;
    private Vector3 priorVelocity = Vector3.zero;
        
    public void FixedUpdate()
    {
        wheelRpms = new List<int>();
            
        foreach (AxleInfo axleInfo in axleInfos) {
            wheelRpms.Add((int)axleInfo.leftWheel.rpm);
            wheelRpms.Add((int)axleInfo.rightWheel.rpm);
        }

        // Broadcast velocity & acceleration
        velocity = transform.InverseTransformDirection(carRigidBody.velocity);
        acceleration = (velocity - priorVelocity)/Time.deltaTime;
        priorVelocity = velocity;

        speedText.text = velocity.z.ToString("F1");
        accelerationText.text = acceleration.ToString();
        rpmsText.text = string.Join(",", wheelRpms);

    }
}
    