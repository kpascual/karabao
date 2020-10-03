using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class TelemetryConnector : NetworkBehaviour
{

    private HUDDisplay gui;
    // Start is called before the first frame update

    public override void OnStartLocalPlayer()
    {
        // Assumes there is a value called TelemetryHUD
        GameObject hud = GameObject.Find("TelemetryHUD");
        gui = hud.GetComponent<HUDDisplay>();

        // Enable listener and communicator for local player only
        ExternalCommunicator ec = gameObject.GetComponent<ExternalCommunicator>();
        ec.enabled = true;
        ExternalListener el = gameObject.GetComponent<ExternalListener>();
        el.enabled = true;

        CarControllerMulti controller = gameObject.GetComponent<CarControllerMulti>();

        // Assumes there exists a toggle called ControlExternalToggle
        Toggle toggle = GameObject.Find("ControlExternalToggle").GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(controller.SetControl);

    }

    public void ListenTelemetry(SensorData sensorData)
    {
        if (isLocalPlayer) {
            gui.ListenSensorChanges(sensorData);
        }
    }

    public void ListenExternalControlCommands(float receivedThrottle, float receivedSteering) {
        Debug.Log("Listening to external controls");
    }

}
