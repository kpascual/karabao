using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;


[System.Serializable]
public class ReceivedControls : UnityEvent<float, float>
{
}

public class ExternalListener : MonoBehaviour
{
    private SubscriberSocket subscriber;
    // Start is called before the first frame update
    private string topic = "controls";
    private Thread thread;
    public string receivedMessage;
    public string host;
    public string port;


    public float steering;
    public float throttle;
    public ReceivedControls receivedControls;

    void Start()
    {
        subscriber = new SubscriberSocket();
        subscriber.Connect("tcp://127.0.0.1:14625");

        subscriber.Subscribe(topic);

        thread = new Thread(Listener);

        thread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        receivedControls?.Invoke(throttle, steering);
    }


    void Listener() {
        while (true)
        {
            string message = subscriber.ReceiveFrameString();

            // Remove topic from message
            int topicIndex = message.IndexOf(topic, StringComparison.Ordinal);
            receivedMessage = (topicIndex < 0) ? message : message.Remove(topicIndex, topic.Length);
            Dictionary<string, float> controlsDict = JsonConvert.DeserializeObject<Dictionary<string, float>>(receivedMessage);

            steering = controlsDict["steering"];
            throttle = controlsDict["throttle"];
        }
    }
}

