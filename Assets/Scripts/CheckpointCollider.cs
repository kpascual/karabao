using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class CheckpointReachedEvent : UnityEvent<int>
{
}


public class CheckpointCollider : MonoBehaviour
{


    Transform playerTransform;   
    //public Text timerText;
    public CheckpointReachedEvent eventCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //string message = "entered checkpoint: " + Time.time;
            //Debug.Log(message);
            //timerText.text = message;
            //LapTimer lapTimer = other.gameObject.GetComponentInParent<LapTimer>();
            //lapTimer.OnCheckpointReached(gameObject.GetInstanceID());
            eventCheckpoint?.Invoke(gameObject.GetInstanceID());
        } else {
            Debug.Log("collided, but wasn't a player");
        }
    }
}
