using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinishCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LapTimer lapTimer = other.gameObject.GetComponentInParent<LapTimer>();
            lapTimer.StartFinishReached();
        } else {
            Debug.Log("collided, but wasn't a player");
        }
    }
}
