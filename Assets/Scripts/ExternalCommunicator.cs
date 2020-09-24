using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NetMQ;
using NetMQ.Sockets;

public class ExternalCommunicator : MonoBehaviour
{

    private PublisherSocket publisher;
    private string topic = "telemetry";
    public string host;
    public string port;
    private SensorData sensorData;

    // Start is called before the first frame update
    void Start()
    {
        publisher = new PublisherSocket();
        publisher.Bind("tcp://127.0.0.1:14623");
        
        sensorData = new SensorData();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SendTelemetry();
    }

    public void ListenCarSensor(SensorData sensors)
    {
        sensorData = sensors;
    }

    void SendTelemetry()
    {
        CameraSensor cameraSensor = GameObject.Find("CarCamera").GetComponent<CameraSensor>();

        Dictionary<string, object> record = new Dictionary<string,object>();
        record["velocity"] = new float[3] {sensorData.velocity.x, sensorData.velocity.y, sensorData.velocity.z};
        record["acceleration"] = new float[3] {sensorData.acceleration.x, sensorData.acceleration.y, sensorData.acceleration.z};
        record["wheelRpms"] = sensorData.wheelRpms;
        record["camera"] = cameraSensor.GetImageBytes();
        string payload = JsonConvert.SerializeObject(record);

        publisher.SendMoreFrame(topic).SendFrame(payload);
    }
}
