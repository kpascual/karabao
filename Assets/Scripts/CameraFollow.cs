using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject cameraMountPoint;
    public Vector3 offset;

    void Start()
    {
            Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
            cameraTransform.parent = cameraMountPoint.transform;  //Make the camera a child of the mount point
            cameraTransform.position = cameraMountPoint.transform.position + offset;  //Set position/rotation same as the mount point
            cameraTransform.rotation = cameraMountPoint.transform.rotation;
    }
}
