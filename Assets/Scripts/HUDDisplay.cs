using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    public Text SpeedText;
    public Text RPMText;
    public Text AccelerationText;

    void Start()
    {
    }

    public void ListenSensorChanges(SensorData sensorData)
    {
        AccelerationText.text = sensorData.acceleration.ToString();
        SpeedText.text = sensorData.velocity.z.ToString("F1");
        RPMText.text = string.Join(",", sensorData.wheelRpms);
    }
}
