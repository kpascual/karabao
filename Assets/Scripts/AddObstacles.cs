using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObstacles : MonoBehaviour
{
    public GameObject obstacleObject;
    public int obstacleCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int[][] regionBoundaries = new int[2][];
        regionBoundaries[0] = new int[4] {12, 24, -60, 60};
        regionBoundaries[1] = new int[4] {-33, -22, -60, 60};
        // Choose which of the regions to spawn
        int region = Random.Range(0, 2);
        int xLow = regionBoundaries[region][0];
        int xHigh = regionBoundaries[region][1];
        int zLow = regionBoundaries[region][2];
        int zHigh = regionBoundaries[region][3];

        Vector3 spawnPosition = new Vector3(Random.Range(xLow, xHigh), 5, Random.Range(zLow, zHigh));
        GameObject clone = Instantiate(obstacleObject, spawnPosition, Quaternion.identity);
    }
}
