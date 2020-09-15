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

    // Start is called before the first frame update
    void Start()
    {
        publisher = new PublisherSocket();
        publisher.Bind("tcp://127.0.0.1:14623");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SendTelemetry();
    }

    void SendTelemetry()
    {
        CarTelemetry component = GameObject.Find("CarRoot").GetComponent<CarTelemetry>();
        CameraSensor cameraSensor = GameObject.Find("CarCamera").GetComponent<CameraSensor>();

        Dictionary<string, object> record = new Dictionary<string,object>();
        record["velocity"] = new float[3] {component.velocity.x, component.velocity.y, component.velocity.z};
        record["acceleration"] = new float[3] {component.acceleration.x, component.acceleration.y, component.acceleration.z};
        record["wheelRpms"] = component.wheelRpms;
        record["camera"] = cameraSensor.GetImageBytes();
        string payload = JsonConvert.SerializeObject(record);

        publisher.SendMoreFrame(topic).SendFrame(payload);
    }
}
