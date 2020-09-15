using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    private Space offsetPositionSpace = Space.Self;
    private Vector3 newPos;
    // Update is called once per frame
    void Update()
    {
        if (offsetPositionSpace == Space.Self) 
        {
            newPos = new Vector3(offset.x, offset.y, offset.z);
            transform.position = player.TransformPoint(newPos);
        }
        transform.LookAt(player);

    }
}
