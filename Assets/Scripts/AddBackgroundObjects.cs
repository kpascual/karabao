using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBackgroundObjects : MonoBehaviour
{

    public GameObject bgObject;
    public int objectCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int[][] regionBoundaries = new int[4][];
        regionBoundaries[0] = new int[4] {25, 45, -50, 50};
        regionBoundaries[1] = new int[4] {-60, -40, -50, 50};
        regionBoundaries[2] = new int[4] {-30, 20, 100, 130};
        regionBoundaries[3] = new int[4] {-30, 20, -120, -100};
        // Choose which of the regions to spawn
        int region = Random.Range(0, 4);
        int xLow = regionBoundaries[region][0];
        int xHigh = regionBoundaries[region][1];
        int zLow = regionBoundaries[region][2];
        int zHigh = regionBoundaries[region][3];

        Vector3 spawnPosition = new Vector3(Random.Range(xLow, xHigh), 0, Random.Range(zLow, zHigh));
        GameObject clone = Instantiate(bgObject, spawnPosition, Quaternion.identity);
    }

}
