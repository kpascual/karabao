using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class SetPlayerNameMulti : NetworkBehaviour
{
    [SyncVar(hook = nameof(ChangePlayerNameClient))] public string playerName;

    public override void OnStartLocalPlayer()
    {
        foreach (Transform t in transform)
        {
            if (t.name == "PlayerName")
            {
                string localName = PlayerPrefs.GetString("carName", "YourCar");

                TMP_Text textObj = t.GetComponent<TMP_Text>(); 
                textObj.text = localName;

                SetPlayerOnServer(localName);
            }
        }
    }

    [Command]
    void SetPlayerOnServer(string setPlayerName)
    {
        playerName = setPlayerName;
    }

    public override void OnStartClient()
    {
        ChangePlayerNameClient("", playerName);
    }

    void ChangePlayerNameClient(string oldClientPlayerName, string newClientPlayerName)
    {
        foreach (Transform t in transform)
        {
            if (t.name == "PlayerName")
            {
                TMP_Text textObj = t.GetComponent<TMP_Text>(); 
                textObj.text = newClientPlayerName;
            }
        }

    }
}
