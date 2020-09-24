using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewCarSensorData", menuName="Car Sensor Data")]
public class CarSensorData : ScriptableObject
{
    // Start is called before the first frame update

    public Vector3 velocity;
    public Vector3 acceleration;
    public List<int> wheelRpms;

    public float throttle;
    public float steering;
    public byte[] cameraImage;
}
