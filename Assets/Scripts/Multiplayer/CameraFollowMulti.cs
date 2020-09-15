using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// Attach this script to a prefab player. 
// This will allow the client's camera to follow the local player

public class CameraFollowMulti : NetworkBehaviour
{
    public GameObject cameraMountPoint;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
            cameraTransform.parent = cameraMountPoint.transform;  //Make the camera a child of the mount point
            cameraTransform.position = cameraMountPoint.transform.position + offset;  //Set position/rotation same as the mount point
            cameraTransform.rotation = cameraMountPoint.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
