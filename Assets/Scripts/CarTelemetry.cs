using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
    


public class SensorData
{
    public Vector3 velocity {get; set;}
    public Vector3 acceleration {get; set;}
    public List<int> wheelRpms {get; set;}
    public byte[] camera {get; set;}
}

[System.Serializable]
public class SensorDataCollected : UnityEvent<SensorData>
{
}

public class CarTelemetry : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public Rigidbody carRigidBody;

    public Vector3 velocity;
    public Vector3 acceleration;
    public List<int> wheelRpms;
    private Vector3 priorVelocity = Vector3.zero;
    public SensorDataCollected sensorDataCollected;
    private SensorData sensors;

    void Start()
    {
        sensors = new SensorData();
        sensors.velocity = Vector3.zero;
        sensors.acceleration = Vector3.zero;
        sensors.wheelRpms = new List<int>(){0,0,0,0};
    }
        
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


        sensors.velocity = velocity;
        sensors.acceleration = acceleration;
        sensors.wheelRpms = wheelRpms;

        sensorDataCollected?.Invoke(sensors);

    }
}
