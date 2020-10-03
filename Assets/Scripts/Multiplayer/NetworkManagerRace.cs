using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerRace : NetworkManager
{
    public Transform cameraMountPoint;
    public List<Transform> spawnPoints = new List<Transform>();
    GameObject player;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        Transform start;
        // spawn ball if two players
        Debug.Log(numPlayers);
        start = spawnPoints[numPlayers];
        player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

    }


    public override void OnClientDisconnect(NetworkConnection conn)
    {
        // Return camera to main place
        Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
        cameraTransform.parent = cameraMountPoint.transform;  //Make the camera a child of the mount point
        cameraTransform.position = cameraMountPoint.transform.position;  //Set position/rotation same as the mount point
        cameraTransform.rotation = cameraMountPoint.transform.rotation;

        base.OnClientDisconnect(conn);
    }
}
