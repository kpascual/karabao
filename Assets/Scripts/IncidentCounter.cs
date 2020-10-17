using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncidentCounter : MonoBehaviour
{
    public int incidentCount;
    public Text hudIncidentText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("collided with an obstacle");
            incidentCount += 1;

            hudIncidentText.text = incidentCount.ToString();
        } else {
            Debug.Log("car collided with non-obstacle");
        }
    }
}
