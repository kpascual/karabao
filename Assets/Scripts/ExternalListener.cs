﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;


public class ExternalListener : MonoBehaviour
{
    private SubscriberSocket subscriber;
    // Start is called before the first frame update
    private string topic = "controls";
    private Thread thread;
    public string receivedMessage;
    public string host;
    public string port;
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
        
    }


    void Listener() {
        while (true)
        {
            string message = subscriber.ReceiveFrameString();

            // Remove topic from message
            int index = message.IndexOf(topic, StringComparison.Ordinal);
            receivedMessage = (index < 0) ? message : message.Remove(index, topic.Length);
            Debug.Log(receivedMessage);
        }
    }
}